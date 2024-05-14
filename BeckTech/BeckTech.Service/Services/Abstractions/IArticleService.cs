using BechTech.Entity.DTO.Articles;
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
        Task<ArticleListDto> GettAllByPagingAync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string? categoryName, string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        //Task<ArticleListDto> SearchCategoryAsync(Guid categoryId, string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDto> SearchAuthorAsync(Guid authorId, string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);

        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleDto>> GetAllArticleslWithCategoryDeletedAync();
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task<ArticleForUserDto> GetArticleWithCategoryForUserNonDeletedAsync(Guid articleId);


        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
       
        Task<List<ArticleDto>> GetTopViewedArticlesWithIncludesAsync();

    }
}
