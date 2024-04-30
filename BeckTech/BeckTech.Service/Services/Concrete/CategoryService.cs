using AutoMapper;
using BechTech.Entity.DTO.Categories;
using BechTech.Entity.Entities;
using BeckTech.Data.UnitOfWorks;
using BeckTech.Service.Extensions;
using BeckTech.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User; //kod tekrarından kaçınmak için burada tanımaldık
        }
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map;
        }

        public async Task<List<CategoryDto>> GetLimitedCategoriesNonDeleted()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map.Take(20).ToList();
        }

        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            Category category = new(categoryAddDto.Name,userEmail);
            await unitOfWork.GetRepository<Category>().AddAsycn(category);
            await unitOfWork.SaveAsync();
        }
        public async Task<Category> GetCategoryByGuid(Guid id)
        {
           var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;

        }

        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = _user.GetLoggedInUserEmail();
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);
            category.Name = categoryUpdateDto.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;

            await unitOfWork.GetRepository<Category>().UpdateAsycn(category);
            await unitOfWork.SaveAsync();
            return category.Name;



        }

        public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {
            var userEmail = _user.GetLoggedInUserEmail(); //İlgili extensions metodunu çağırıp user mail yi çekiyoruz

            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Category>().UpdateAsycn(category);
            await unitOfWork.SaveAsync();
            return category.Name;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map;
        }

        public async Task<string> UndoDeleteCategoryAsync(Guid categoryId)
        {

            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;

            await unitOfWork.GetRepository<Category>().UpdateAsycn(category);
            await unitOfWork.SaveAsync();
            return category.Name;
        }

       
    }
}
