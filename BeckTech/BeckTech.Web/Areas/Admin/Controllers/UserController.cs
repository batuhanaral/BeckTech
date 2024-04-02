using AutoMapper;
using BechTech.Entity.DTO.Article;
using BechTech.Entity.DTO.Users;
using BechTech.Entity.Entities;
using BeckTech.Service.Extensions;
using BeckTech.Web.ResultMessages;
using FluentValidation;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IValidator<AppUser> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IValidator<AppUser> validator, IMapper mapper, IToastNotification toastNotification)
        {
            this._userManager = userManager;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.roleManager = roleManager;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(user);

            foreach (var userDto in map)
            {
                var findUser = await _userManager.FindByIdAsync(userDto.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser));

                userDto.Role = role;

            }

            return View(map);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(new UserAddDto { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await roleManager.Roles.ToListAsync();

            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;
                var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await _userManager.AddToRoleAsync(map, findRole.ToString());
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı" });//başarı mesajı gönderme
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
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await roleManager.Roles.ToListAsync();
            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            if (user != null)
            {
                var userRole = string.Join("", await _userManager.GetRolesAsync(user));
                var roles = await roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            await _userManager.RemoveFromRoleAsync(user, userRole);
                            var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                            await _userManager.AddToRoleAsync(user, findRole.Name);
                            toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı" });//başarı mesajı gönderme
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            validation.AddToModelState(this.ModelState);

                            return View(new UserAddDto { Roles = roles });

                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserAddDto { Roles = roles });


                    }
                }
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await roleManager.Roles.ToListAsync();
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                toastNotification.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Başarılı" });//başarı mesajı gönderme
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);

                return View(new UserAddDto { Roles = roles });

            }


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