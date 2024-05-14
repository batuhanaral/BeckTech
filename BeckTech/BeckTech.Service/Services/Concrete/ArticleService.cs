using BeckTech.Service.Services.Abstractions;
using BeckTech.Data.UnitOfWorks;
using BechTech.Entity.DTO.Articles;
using AutoMapper;
using BechTech.Entity.Entities;
using Microsoft.AspNetCore.Http;
using BeckTech.Service.Extensions;
using System.Security.Claims;
using BeckTech.Service.Helpers.Images;
using BechTech.Entity.Enums;
using System.Linq.Expressions;

namespace BeckTech.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;


        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this._imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User; //kod tekrarından kaçınmak için burada tanımaldık
        }

       

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userId = _user.GetLoggedInUserId(); //İlgili extensions metodunu çağırıp userId yi çekiyoruz
            var userEmail = _user.GetLoggedInUserEmail(); //İlgili extensions metodunu çağırıp user mail yi çekiyoruz
            
            var imageUpload = await _imageHelper.Upload(articleAddDto.Title,articleAddDto.Photo,ImageType.Post);
            Image image = new(imageUpload.FullName,articleAddDto.Photo.ContentType,userEmail);

            await _unitOfWork.GetRepository<Image>().AddAsycn(image);


            var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, userEmail, articleAddDto.CategoryId, image.Id);



            await _unitOfWork.GetRepository<Article>().AddAsycn(article);
            await _unitOfWork.SaveAsync();

        }



        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInUserEmail(); //İlgili extensions metodunu çağırıp user mail yi çekiyoruz

            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy== userEmail, x => x.Category);//Silinmemiş articleları getir ve categoryleri include ediyor.
            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;
        }



        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category,i=>i.Image);//İlgili article getir ve categorysini include ediyor.
            var map = mapper.Map<ArticleDto>(articles);

            return map;
        }

        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInUserEmail(); //İlgili extensions metodunu çağırıp user mail yi çekiyoruz

            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category,i=>i.Image);

            if (articleUpdateDto.Photo != null)
            {
                // Eski fotoğrafın silinmesi
                if (!string.IsNullOrEmpty(article.Image.FileName))
                {
                    _imageHelper.Delete(article.Image.FileName);
                }

                var imageUpload = await _imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName,articleUpdateDto.Photo.ContentType,userEmail);
                await _unitOfWork.GetRepository<Image>().AddAsycn(image);

                article.ImageId = image.Id;
            }
            else
            {
                var getArticlesForImageId = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);
                article.ImageId = getArticlesForImageId.ImageId;
            }
            //mapper.Map(articleUpdateDto, article);
            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;

            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            await _unitOfWork.GetRepository<Article>().UpdateAsycn(article);
            await _unitOfWork.SaveAsync();
            return article.Title;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInUserEmail(); //İlgili extensions metodunu çağırıp user mail yi çekiyoruz

            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await _unitOfWork.GetRepository<Article>().UpdateAsycn(article);
            await _unitOfWork.SaveAsync();
            return article.Title;
        }

        public async Task<List<ArticleDto>> GetAllArticleslWithCategoryDeletedAync()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;
        }

        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {

            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await _unitOfWork.GetRepository<Article>().UpdateAsycn(article);
            await _unitOfWork.SaveAsync();
            return article.Title;
        }

        public async Task<ArticleListDto> GettAllByPagingAync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryId == null ? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
                                             : await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted, x => x.Category, i => i.Image, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count(),
                IsAscending = isAscending,
                
            };

        }


        public async Task<ArticleListDto> SearchAsync(string? categoryName, string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryName == null ? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword) || a.User.FirstName.Contains(keyword) ), a => a.Category, i => i.Image, u => u.User)
                                            : await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.Category.Name.Contains(categoryName) && !a.IsDeleted, x => x.Category, i => i.Image, u => u.User);



            //var articles = await _unitOfWork.GetRepository<Article>().
            //    GetAllAsync(a => !a.IsDeleted && (a.Title.Contains(keyword)|| a.Content.Contains(keyword) ||a.Category.Name.Contains(keyword) ) , a => a.Category, i => i.Image, u => u.User);





            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count(),
                IsAscending = isAscending
            };
        }

        public async Task<ArticleListDto> SearchAuthorAsync(Guid authorId, string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted && a.UserId== authorId, a => a.Category, i => i.Image, u => u.User);
                                            


            //var articles = await _unitOfWork.GetRepository<Article>().
            //    GetAllAsync(a => !a.IsDeleted && (a.Title.Contains(keyword)|| a.Content.Contains(keyword) ||a.Category.Name.Contains(keyword) ) , a => a.Category, i => i.Image, u => u.User);





            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count(),
                IsAscending = isAscending,
                
            };
        }



        //public async Task<ArticleListDto> SearchCategoryAsync(Guid categoryId, string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        //{
        //    pageSize = pageSize > 20 ? 20 : pageSize;

        //    var articles = await _unitOfWork.GetRepository<Article>().
        //        GetAllAsync(a => !a.IsDeleted && a.CategoryId==categoryId, a => a.Category, i => i.Image, u => u.User);





        //    var sortedArticles = isAscending
        //        ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).ToList()
        //        : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        //    return new ArticleListDto
        //    {
        //        Articles = sortedArticles,
        //        CurrentPage = currentPage,
        //        PageSize = pageSize,
        //        TotalCount = articles.Count(),
        //        IsAscending = isAscending
        //    };
        //}


        public async Task<ArticleForUserDto> GetArticleWithCategoryForUserNonDeletedAsync(Guid articleId)
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image, c => c.User);
            var map = mapper.Map<ArticleForUserDto>(articles);

            return map;
        }


       



        public async Task<List<ArticleDto>> GetTopViewedArticlesWithIncludesAsync()
        {
            Expression<Func<Article, bool>> predicate = x => !x.IsDeleted;
            Func<IQueryable<Article>, IOrderedQueryable<Article>> orderBy = q => q.OrderByDescending(x => x.ViewCount);
            Expression<Func<Article, object>>[] includeProperties =
            {
                x => x.Image,
                x => x.Category,
                x => x.User
            };

            var articles = await _unitOfWork.GetRepository<Article>().GetAll2Async(predicate, orderBy, includeProperties, take: 3);

            return mapper.Map<List<ArticleDto>>(articles);
        }


    }
}
