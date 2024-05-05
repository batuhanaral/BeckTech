﻿using AutoMapper;
using BechTech.Entity.DTO.Categories;
using BechTech.Entity.DTO.Contact;
using BechTech.Entity.Entities;
using BeckTech.Service.Extensions;
using BeckTech.Service.Services.Abstractions;
using BeckTech.Web.Models;
using BeckTech.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;

namespace BeckTech.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService contactService;
        private readonly IValidator<Contact> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;
        private readonly IArticleService articleService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IVisitorService visitorService;

        public HomeController(ILogger<HomeController> logger, IContactService contactService, IValidator<Contact> validator, IMapper mapper, IToastNotification toastNotification,IArticleService articleService,IHttpContextAccessor httpContextAccessor,IVisitorService visitorService)
        {
            _logger = logger;
            this.contactService = contactService;
            this.validator = validator;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.articleService = articleService;
            this.httpContextAccessor = httpContextAccessor;
            this.visitorService = visitorService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Services()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Blog(Guid? categoryId,int currentPage=1,int pageSize=5, bool isAscending= false)
        {
            var articles = await articleService.GettAllByPagingAync(categoryId, currentPage, pageSize, isAscending);
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? categoryName, string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            ViewBag.Keyword = keyword;
            if(categoryName != null)
                ViewBag.CategoryName = categoryName;

            var articles = await articleService.SearchAsync(categoryName, keyword, currentPage, pageSize, isAscending);
            return View( articles); 
        }
        [HttpGet]
        public async Task<IActionResult> Author(Guid authorId, string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {

            var articles = await articleService.SearchAuthorAsync(authorId, keyword, currentPage, pageSize, isAscending);
            ViewBag.AuthorId = authorId;
            return View(articles);
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            var article = await visitorService.AddVisitor(id); 
            return View(article);
        }

        public async Task<IActionResult> AboutUs()
        {
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
        public async Task<IActionResult> WebDevelopment()
        {
            return View();
        }
        public async Task<IActionResult> DigitalMarketing()
        {
            return View();
        }
        public async Task<IActionResult> DigitalBusinessCard()
        {
            return View();
        }
        public async Task<IActionResult> SeoService()
        {
            return View();
        }
        public async Task<IActionResult> SocialMediaManagement()
        {
            return View();
        }
        public async Task<IActionResult> ContentWriting()
        {
            return View();
        }
        public async Task<IActionResult> BatuhanAral()
        {
            return View();
        }
        public async Task<IActionResult> CagatayArslan()
        {
            return View();
        }
        public async Task<IActionResult> EymenDogan()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactDto contactDto)
        {
            var map = mapper.Map<Contact>(contactDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid) 
            {
                await contactService.CreateContacteAsync(contactDto);
                toastNotification.AddSuccessToastMessage(Messages.Contact.Add(), new ToastrOptions { Title = "Başarılı" });//başarı mesajı gönderme
                return RedirectToAction("Index", "Home");
            }
            result.AddToModelState(this.ModelState);//başarısızsa aynı view geri döncek
            return View();
        }



        public IActionResult Error1(int? code)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}