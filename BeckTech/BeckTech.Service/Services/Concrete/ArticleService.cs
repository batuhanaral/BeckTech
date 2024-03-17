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

        public ArticleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<List<ArticleDto>> GetAllArticlesAsync()
        {
            var articles=  await _unitOfWork.GetRepository<Article>().GetAllAsync();
            var map = mapper.Map<List<ArticleDto>>(articles);

            return map;
        }
    }
}
