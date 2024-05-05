using AutoMapper;
using BechTech.Entity.DTO.Articles;
using BechTech.Entity.Entities;
using BechTech.Entity.Enums;
using BeckTech.Data.UnitOfWorks;
using BeckTech.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Concrete
{
    public class VisitorService :IVisitorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IArticleService articleService;

        public VisitorService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor,IArticleService articleService )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.articleService = articleService;
        }

        public async Task<ArticleForUserDto> AddVisitor(Guid id)
        {
            var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var articleVisitors = await unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x=>x.Visitor,y=>y.Article);
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == id);

            var visitor = await unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

            var addArticleVisitor = new ArticleVisitor(article.Id, visitor.Id);
            if (articleVisitors.Any(x => x.VisitorId == addArticleVisitor.VisitorId && x.ArticleId == addArticleVisitor.ArticleId))
            {
                var article2 = await articleService.GetArticleWithCategoryForUserNonDeletedAsync(id);

                return article2;
            }
            else
            {
                await unitOfWork.GetRepository<ArticleVisitor>().AddAsycn(addArticleVisitor);
                article.ViewCount ++ ;
                await unitOfWork.GetRepository<Article>().UpdateAsycn(article);
                await unitOfWork.SaveAsync();
                var article2 = await articleService.GetArticleWithCategoryForUserNonDeletedAsync(id);

                return article2;
            }
        }

    }
}
