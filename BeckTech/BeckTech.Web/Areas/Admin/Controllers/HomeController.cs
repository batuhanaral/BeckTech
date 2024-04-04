using BechTech.Entity.Entities;
using BeckTech.Service.Services.Abstractions;
using BeckTech.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeckTech.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }
      
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var articles= await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
    }
}
