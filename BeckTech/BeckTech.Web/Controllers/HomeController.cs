using AutoMapper;
using BechTech.Entity.DTO.Categories;
using BechTech.Entity.DTO.Contact;
using BechTech.Entity.Entities;
using BeckTech.Service.Extensions;
using BeckTech.Service.Services.Abstractions;
using BeckTech.Web.Consts;
using BeckTech.Web.Models;
using BeckTech.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IContactService contactService, IValidator<Contact> validator, IMapper mapper, IToastNotification toastNotification,IArticleService articleService,IHttpContextAccessor httpContextAccessor,IVisitorService visitorService, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.contactService = contactService;
            this.validator = validator;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.articleService = articleService;
            this.httpContextAccessor = httpContextAccessor;
            this.visitorService = visitorService;
            this.webHostEnvironment = webHostEnvironment;
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
            var article = await articleService.GetArticleWithCategoryForUserNonDeletedAsync(id); 
            return View(article);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                var fileName = DateTime.Now.ToString("ddMMyyyy") + "_" + Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);
                var uploadsFolderPath = Path.Combine(webHostEnvironment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var filePath = Path.Combine(uploadsFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(stream);
                }

                // CKEditor'in beklediği formatta JSON dönüş
                return Json(new { uploaded = true, url = "/uploads/" + fileName });
            }

            return Json(new { uploaded = false });
        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin}")]
        public async Task<IActionResult> UploadExplorer()
        {
            var uploadsFolderPath = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
            var dir = new DirectoryInfo(uploadsFolderPath);
            var files = dir.GetFiles().OrderByDescending(f => f.CreationTime).ToArray(); // Dosyaları tarihe göre sırala
            ViewBag.FileInfo = files;
            return View("FileExplorer");
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
        public async Task<IActionResult> OsmanSefaKoroglu()
        {
            return View();
        }
        public async Task<IActionResult> UmutYalvarmaz()
        {
            return View();
        }

        public async Task<IActionResult> HaticeAtabey()
        {
            return View();
        }
        public async Task<IActionResult> BernaAltuntas()
        {
            return View();
        }
        public async Task<IActionResult> IbrahimDundar()
        {
            return View();
        }
        public async Task<IActionResult> EslemKisacik()
        {
            return View();
        }
        public async Task<IActionResult> MertcanUcar()
        {
            return View();
        }
        public async Task<IActionResult> MahmutKarakus()
        {
            return View();
        }
        public async Task<IActionResult> EminTohumcu()
        {
            return View();
        }
        public async Task<IActionResult> DuyguDogan()
        {
            return View();
        }
        public async Task<IActionResult> ZeynepKalaycioglu()
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