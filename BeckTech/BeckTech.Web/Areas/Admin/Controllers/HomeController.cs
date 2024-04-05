using BechTech.Entity.Entities;
using BeckTech.Service.Services.Abstractions;
using BeckTech.Service.Services.Concrete;
using BeckTech.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BeckTech.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IDashBoardService dashBoardService;

        public HomeController(IArticleService articleService,IDashBoardService dashBoardService)
        {
            this.articleService = articleService;
            this.dashBoardService = dashBoardService;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            //var articles= await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            //return View(articles);
            return View();  
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> YearlyArticleCounts()
        {
            var count = await dashBoardService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> YearlyArticleCountsForUser()
        {
            var count = await dashBoardService.GetYearlyArticleCountsForUser();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await dashBoardService.GetTotalArticleCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCountForUser()
        {
            var count = await dashBoardService.GetTotalArticleCountForUser();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await dashBoardService.GetTotalCategoryCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalCategoryCountForUser()
        {
            var count = await dashBoardService.GetTotalCategoryCountForUser();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalViewCount()
        {
            var count = await dashBoardService.GetTotalViewCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalViewCountForUser()
        {
            var count = await dashBoardService.GetTotalViewCountForUser();
             return Json(count); // Görüntü sayısını JSON olarak döndürüyoruz.
        }
    }
}
