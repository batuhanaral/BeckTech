using AutoMapper;
using BechTech.Entity.DTO.Article;
using BechTech.Entity.DTO.Categories;
using BechTech.Entity.Entities;
using BeckTech.Service.Extensions;
using BeckTech.Service.Services.Abstractions;
using BeckTech.Service.Services.Concrete;
using BeckTech.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;

namespace BeckTech.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Category> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public CategoryController( ICategoryService categoryService,IValidator<Category> validator,IMapper mapper,IToastNotification toastNotification)
        {
            this._categoryService = categoryService;
            this._validator = validator;
            this._mapper = mapper;
            this._toastNotification = toastNotification;
        }
     
        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }
        
        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]


        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]

        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
           var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarılı" });//başarı mesajı gönderme
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            
                result.AddToModelState(this.ModelState);//başarısızsa aynı view geri döncek
                return View();

            
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]

        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarılı" });//başarı mesajı gönderme
                return Json(Messages.Category.Add(categoryAddDto.Name));
            }
            else
            {
                _toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });//başarı mesajı gönderme
                return Json(result.Errors.First().ErrorMessage);

            }
            


        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await _categoryService.GetCategoryByGuid(categoryId);
            var map = _mapper.Map<Category,CategoryUpdateDto>(category);
            if (map != null)
            {
                return View(map);
            }
            return View();
        }
       
        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]

        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var map = _mapper.Map<Category>(categoryUpdateDto);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                var name = await _categoryService.UpdateCategoryAsync(categoryUpdateDto);
                _toastNotification.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "Başarılı" });//başarı mesajı gönderme
                return RedirectToAction("Index", "Category", new { Area = "Admin" });

            }

            result.AddToModelState(this.ModelState);//başarısızsa aynı view geri döncek
            return View();

        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var title = await _categoryService.SafeDeleteCategoryAsync(categoryId);
            _toastNotification.AddSuccessToastMessage(Messages.Category.Delete(title), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeletedCategories()
        {
            var categories = await _categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> UndoDelete(Guid categoryId)
        {
            var title = await _categoryService.UndoDeleteCategoryAsync(categoryId);
            _toastNotification.AddSuccessToastMessage(Messages.Category.UndoDelete(title), new ToastrOptions { Title = "Başarılı" });

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}
