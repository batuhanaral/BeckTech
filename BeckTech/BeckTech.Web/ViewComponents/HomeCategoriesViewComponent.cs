using BeckTech.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BeckTech.Web.ViewComponents
{
    public class HomeCategoriesViewComponent :ViewComponent
    {
        private readonly ICategoryService categoryService;

        public HomeCategoriesViewComponent(ICategoryService categoryService )
        {
            this.categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryService.GetLimitedCategoriesNonDeleted();
            return View( categories );
        }
        
    }
}
