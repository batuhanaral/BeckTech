using BeckTech.Service.Services.Abstractions;
using BeckTech.Data.UnitOfWorks;
using BechTech.Entity.DTO.Article;
using AutoMapper;
using BechTech.Entity.Entities;

namespace BeckTech.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userId = Guid.Parse("0B66F151-E4AB-4A80-B867-6B868CF2E400");
            var imageId = Guid.Parse("006B8234-53E7-4482-A70D-B36C12304432");

            var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, articleAddDto.CategoryId, imageId);
          
            await _unitOfWork.GetRepository<Article>().AddAsycn(article);
            await _unitOfWork.SaveAsync();

        }

       

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles=  await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted,x=> x.Category);//Silinmemiş articleları getir ve categoryleri include ediyor.
            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;
        }

        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId  , x => x.Category);//İlgili article getir ve categorysini include ediyor.
            var map = mapper.Map<ArticleDto>(articles);

            return map;
        }

        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;

            await _unitOfWork.GetRepository<Article>().UpdateAsycn(article);
            await _unitOfWork.SaveAsync();
            return article.Title;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Article>().UpdateAsycn(article);
            await _unitOfWork.SaveAsync();
            return article.Title;
        }
    }
}
