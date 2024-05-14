using BeckTech.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BeckTech.Web.ViewComponents
{
    public class MostReadIndexViewComponent : ViewComponent
    {
        private readonly IArticleService articleService;

        public MostReadIndexViewComponent(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await articleService.GetTopViewedArticlesWithIncludesAsync();
            return View(articles); // Makalelerin listesini görünüme geçirin
        }
    }
}
