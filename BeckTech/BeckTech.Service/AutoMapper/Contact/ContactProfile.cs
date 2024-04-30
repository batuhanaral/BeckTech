using AutoMapper;
using BechTech.Entity.DTO.Contact;
using BechTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.AutoMapper.ContactProfile
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();
        }
    }
}
