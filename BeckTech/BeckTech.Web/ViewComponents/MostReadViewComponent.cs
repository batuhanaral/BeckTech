using BeckTech.Service.Services.Abstractions;
using BeckTech.Service.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BeckTech.Web.ViewComponents
{
    public class MostReadViewComponent : ViewComponent
    {
        private readonly IArticleService articleService;

        public MostReadViewComponent(IArticleService articleService)
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
