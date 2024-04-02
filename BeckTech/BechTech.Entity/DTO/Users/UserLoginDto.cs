using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BechTech.Entity.DTO.Users
{
    public class UserLoginDto
    {

        [Required(ErrorMessage = "E-posta adresi gereklidir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
