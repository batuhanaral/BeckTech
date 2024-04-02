using BeckTech.Service.Services.Abstractions;
using BeckTech.Data.UnitOfWorks;
using BechTech.Entity.DTO.Article;
using AutoMapper;
using BechTech.Entity.Entities;
using Microsoft.AspNetCore.Http;
using BeckTech.Service.Extensions;
using System.Security.Claims;
using BeckTech.Service.Helpers.Images;
using BechTech.Entity.Enums;

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
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);//Silinmemiş articleları getir ve categoryleri include ediyor.
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
    }
}
