using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Abstractions
{
    public interface IDashBoardService
    {
        Task<List<int>> GetYearlyArticleCounts();
        Task<List<int>> GetYearlyArticleCountsForUser();

        Task<int> GetTotalArticleCount();
        Task<int> GetTotalArticleCountForUser();

        Task<int> GetTotalCategoryCount();
        Task<int> GetTotalCategoryCountForUser();

        Task<int> GetTotalViewCount();
        Task<int> GetTotalViewCountForUser();
    }
}
