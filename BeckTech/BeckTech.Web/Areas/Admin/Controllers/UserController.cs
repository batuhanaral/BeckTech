using AutoMapper;
using BechTech.Entity.DTO.Articles;
using BechTech.Entity.DTO.Users;
using BechTech.Entity.Entities;
using BeckTech.Service.Extensions;
using BeckTech.Service.Services.Abstractions;
using BeckTech.Web.Consts;
using BeckTech.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Data;

namespace BeckTech.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IValidator<AppUser> validator;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IValidator<AppUser> validator, IToastNotification toast, IMapper mapper)
        {
            this.userService = userService;
            this.validator = validator;
            this.toast = toast;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Index()
        {
            var result = await userService.GetAllUsersWithRoleAsync();

            return View(result);

        }
        
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Add()
        {
            var roles = await userService.GetAllRolesAsync();
            return View(new UserAddDto { Roles = roles });
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await userService.GetAllRolesAsync();

            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });

                }
            }
            return View(new UserAddDto { Roles = roles });
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userService.GetAppUserByIdAsync(userId);

            var roles = await userService.GetAllRolesAsync();

            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;
            return View(map);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null)
            {
                var roles = await userService.GetAllRolesAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
            }
            return NotFound();

        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await userService.DeleteUserAsync(userId);

            if (result.identityResult.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();


        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Profile()
        {
            var profile = await userService.GetUserProfileAsync();

            return View(profile);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.SuperAdmin},{RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.UserProfileUpdateAsync(userProfileDto);
                if (result)
                {
                    toast.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı", new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    toast.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı", new ToastrOptions { Title = "İşlem Başarısız" });
                    return View(profile);
                }
            }
            else
                return NotFound();
        }
    

    }

}
/*

[HttpGet]
       public async Task<IActionResult> Update(Guid userId)
       {
           var user = await _userManager.GetAppUserByIdAsync(userId);

           var roles = await _userManager.GetAllRolesAsync();

           var map = mapper.Map<UserUpdateDto>(user);
           map.Roles = roles;
           return View(map);
       }
       [HttpPost]
       public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
       {
           var user = await _userManager.GetAppUserByIdAsync(userUpdateDto.Id);

           if (user != null)
           {
               var roles = await _userManager.GetAllRolesAsync();
               if (ModelState.IsValid)
               {
                   var map = mapper.Map(userUpdateDto, user);
                   var validation = await validator.ValidateAsync(map);

                   if (validation.IsValid)
                   {
                       user.UserName = userUpdateDto.Email;
                       user.SecurityStamp = Guid.NewGuid().ToString();
                       var result = await _userManager.UpdateUserAsync(userUpdateDto);
                       if (result.Succeeded)
                       {
                           toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                           return RedirectToAction("Index", "User", new { Area = "Admin" });
                       }
                       else
                       {
                           result.AddToIdentityModelState(this.ModelState);
                           return View(new UserUpdateDto { Roles = roles });
                       }
                   }
                   else
                   {
                       validation.AddToModelState(this.ModelState);
                       return View(new UserUpdateDto { Roles = roles });
                   }
               }
           }
           return NotFound();
       }
   }

 */