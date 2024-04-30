using BeckTech.Data.Context;
using BeckTech.Data.Repositories.Abtractions;
using BeckTech.Data.Repositories.Concretes;
using BeckTech.Data.UnitOfWorks;
using BeckTech.Service.FluentValidations;
using BeckTech.Service.Helpers.Images;
using BeckTech.Service.Services.Abstractions;
using BeckTech.Service.Services.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDashBoardService,DashboardService>();
            services.AddScoped<IContactService,ContactService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//Login olan kullanıcıyı bulmamız için
            


            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                opt.DisableDataAnnotationsValidation = true; //data annotationsları geçersiz kıldık
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr"); //dil tanımladık
            });

            return services;
        }
    }
}
