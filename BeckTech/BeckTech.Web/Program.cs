using BechTech.Entity.Entities;
using BeckTech.Data.Context;
using BeckTech.Data.Extensions;
using BeckTech.Service.Describers;
using BeckTech.Service.Extensions;
using BeckTech.Web.Filters.ArticleVisitors;
using Microsoft.AspNetCore.Identity;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add<ArticleVisitorFilter>();
})
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopCenter,
        TimeOut = 2500,
        ProgressBar = true,
    })
    .AddRazorRuntimeCompilation();
builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.AddSession();
builder.Services.LoadServiceLayerExtensions();

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{ //canlýda kalkcak
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityDescriber>()
    .AddEntityFrameworkStores<BeckTechDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "BeckTech",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest,//canlya çýkýnca always olacak
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(1);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Home/Error1", "?code={0}");
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapDefaultControllerRoute();

    endpoints.MapControllerRoute(
            name: "BatuhanAral",
            pattern: "BatuhanAral",
            defaults: new { controller = "Home", action = "BatuhanAral" }
        );

    endpoints.MapControllerRoute(
           name: "CagatayArslan",
           pattern: "CagatayArslan",
           defaults: new { controller = "Home", action = "CagatayArslan" }
       );

    endpoints.MapControllerRoute(
           name: "EymenDogan",
           pattern: "EymenDogan",
           defaults: new { controller = "Home", action = "EymenDogan" }
       );
    endpoints.MapControllerRoute(
          name: "Ýletiþim",
          pattern: "Ýletiþim",
          defaults: new { controller = "Home", action = "Contact" }
      );
    endpoints.MapControllerRoute(
         name: "Hakkýmýzda",
         pattern: "Hakkýmýzda",
         defaults: new { controller = "Home", action = "AboutUs" }
     );
    endpoints.MapControllerRoute(
         name: "Hizmetlerimiz",
         pattern: "Hizmetlerimiz",
         defaults: new { controller = "Home", action = "Services" }
     );

});

app.Run();
