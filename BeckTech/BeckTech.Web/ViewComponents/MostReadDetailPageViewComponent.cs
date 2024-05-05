using BeckTech.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BeckTech.Web.ViewComponents
{
    public class MostReadDetailPageViewComponent : ViewComponent
    {
        private readonly IArticleService articleService;

        public MostReadDetailPageViewComponent(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await articleService.GetMostReadArticleslWithCategoryDeletedAync();
            return View(articles); // Makalelerin listesini görünüme geçirin
        }

    }
}
