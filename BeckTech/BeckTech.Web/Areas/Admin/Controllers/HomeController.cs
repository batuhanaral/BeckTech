using AutoMapper;
using BechTech.Entity.DTO.Categories;
using BechTech.Entity.DTO.Contact;
using BechTech.Entity.Entities;
using BeckTech.Service.Extensions;
using BeckTech.Service.Services.Abstractions;
using BeckTech.Service.Services.Concrete;
using BeckTech.Web.Consts;
using BeckTech.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace BeckTech.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IDashBoardService dashBoardService;
        private readonly IContactService contactService;
        private readonly IToastNotification toastNotification;
        private readonly IMapper mapper;
        private readonly IValidator<Contact> validator;

        public HomeController(IArticleService articleService,IDashBoardService dashBoardService, IContactService contactService,IToastNotification toastNotification,IMapper mapper, IValidator<Contact> validator)
        {
            this.articleService = articleService;
            this.dashBoardService = dashBoardService;
            this.contactService = contactService;
            this.toastNotification = toastNotification;
            this.mapper = mapper;
            this.validator = validator;
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

        //[HttpPost]
        //public async Task<IActionResult> AddContact(ContactDto contactDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var map = mapper.Map<Contact>(contactDto);
        //        var result = await validator.ValidateAsync(map);
        //        if (result.IsValid) 
        //        {
        //            await contactService.CreateContacteAsync(contactDto);
        //            toastNotification.AddSuccessToastMessage(Messages.Contact.Add(), new ToastrOptions { Title = "Başarılı" });//başarı mesajı gönderme
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            result.AddToModelState(this.ModelState);//başarısızsa aynı view geri döncek
        //            return View();
        //        }
                   


        //    }

        //    return View(contactDto);
        //}
    }
}
