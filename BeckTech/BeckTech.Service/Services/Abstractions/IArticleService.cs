using BechTech.Entity.DTO.Article;
using BechTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);

        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid articleId);


    }
}
