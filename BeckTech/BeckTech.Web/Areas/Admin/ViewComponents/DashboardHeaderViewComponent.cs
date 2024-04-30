using AutoMapper;
using BechTech.Entity.DTO.Users;
using BechTech.Entity.Entities;
using BeckTech.Service.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeckTech.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper, IUserService userService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            var map =mapper.Map<UserDto>(loggedInUser);
            var role = string.Join("", await userManager.GetRolesAsync(loggedInUser));
            map.Role = role;

            var user = await userService.GetUserProfileAsync();
            ViewBag.ProfileImage = user.Image.FileName;
            return View(map);
        }
    }
}
