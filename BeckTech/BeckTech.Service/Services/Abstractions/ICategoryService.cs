using BechTech.Entity.DTO.Articles;
using BechTech.Entity.DTO.Categories;
using BechTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task<List<CategoryDto>> GetLimitedCategoriesNonDeleted();

        Task<List<CategoryDto>> GetAllCategoriesDeleted();
        Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
        Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        Task<Category> GetCategoryByGuid(Guid id);
        Task<string> UndoDeleteCategoryAsync(Guid categoryId);
        Task<CategoryListDto> GettAllByPagingAync(int currentPage = 1, int pageSize = 3, bool isAscending = false);
    }
}
                      