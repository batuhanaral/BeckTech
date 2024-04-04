using AutoMapper;
using BechTech.Entity.DTO.Categories;
using BechTech.Entity.DTO.Users;
using BechTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<AppUser, UserAddDto>().ReverseMap();
            CreateMap<AppUser, UserUpdateDto>().ReverseMap();

            CreateMap<UserProfileDto, AppUser>()
                .ForMember(dest => dest.ImageId, opt => opt.Ignore()) // ImageId özelliğini haritalamadan çıkar
                .ForMember(dest => dest.Image, opt => opt.Ignore())  // Image özelliğini haritalamadan çıkar
                .ReverseMap();  // İki yönlü haritalama için ReverseMap'ı ekleyin
        }
    }
}
