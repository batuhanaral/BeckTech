using BechTech.Entity.Entities;
using BeckTech.Data.UnitOfWorks;
using BeckTech.Service.Extensions;
using BeckTech.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Concrete
{
    public class DashboardService : IDashBoardService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ClaimsPrincipal _user;
        private readonly IHttpContextAccessor httpContextAccessor;



        public DashboardService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<int>> GetYearlyArticleCounts()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endedDate = startedDate.AddMonths(1);
                var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }

            return datas;
        }

        public async Task<List<int>> GetYearlyArticleCountsForUser()
        {
            var userEmail = _user.GetLoggedInUserEmail();//kullanıcının emailini bulur

            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy ==userEmail);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endedDate = startedDate.AddMonths(1);
                var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }

            return datas;
        }

        public async Task<int> GetTotalArticleCount()
        {
            var articleCount = await unitOfWork.GetRepository<Article>().CountAsycn(x => !x.IsDeleted);
            return articleCount;
        }
        public async Task<int> GetTotalArticleCountForUser()
        {
            var userEmail = _user.GetLoggedInUserEmail(); 

            var articleCount = await unitOfWork.GetRepository<Article>().CountAsycn(x => !x.IsDeleted&&x.CreatedBy== userEmail);
            return articleCount;
        }
      
        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await unitOfWork.GetRepository<Category>().CountAsycn(x => !x.IsDeleted);
            return categoryCount;
        }
        public async Task<int> GetTotalCategoryCountForUser()
        {
            var userEmail = _user.GetLoggedInUserEmail(); 

            var categoryCount = await unitOfWork.GetRepository<Category>().CountAsycn(x => !x.IsDeleted&&x.CreatedBy == userEmail);
            return categoryCount;
        }



        public async Task<int> GetTotalViewCount()
        {
            var viewCount = await unitOfWork.GetRepository<Article>().SumAsync(x => x.ViewCount);
            return viewCount;
        }
        public async Task<int> GetTotalViewCountForUser()
        {
            var userEmail = _user.GetLoggedInUserEmail(); //İlgili extensions metodunu çağırıp user mail yi çekiyoruz

            if (userEmail == null)
            {
                // Kullanıcı bulunamazsa 0 olarak döndürebilirsiniz veya isteğinize göre farklı bir işlem yapabilirsiniz.
                return 0;
            }

            var viewCount = await unitOfWork.GetRepository<Article>().SumAsync(x => x.ViewCount, x => x.CreatedBy == userEmail);
            return viewCount;
        }

    }
}
