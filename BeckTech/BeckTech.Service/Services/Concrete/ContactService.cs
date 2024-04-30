using AutoMapper;
using BechTech.Entity.DTO.Contact;
using BechTech.Entity.Entities;
using BeckTech.Data.UnitOfWorks;
using BeckTech.Service.Extensions;
using BeckTech.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public ContactService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User; //kod tekrarından kaçınmak için burada tanımaldık
        }
        public async Task<bool> CreateContacteAsync(ContactDto contactDto)
        {
            var map = mapper.Map<Contact>(contactDto);
            map.CreatedBy = contactDto.Email;
            map.Message = contactDto.Message;
            await _unitOfWork.GetRepository<Contact>().AddAsycn(map);
            await _unitOfWork.SaveAsync();
           
            return true;
                
                
        }

        public async Task<List<ContactDto>> GetAllContactNonDeletedAsync()
        {
            var contacts = await _unitOfWork.GetRepository<Contact>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<ContactDto>>(contacts);
            return map;
        }

        public async Task<string> SafeDeleteContactAsync(Guid contactId)
        {
            var userEmail = _user.GetLoggedInUserEmail(); //İlgili extensions metodunu çağırıp user mail yi çekiyoruz

            var contact = await _unitOfWork.GetRepository<Contact>().GetByGuidAsync(contactId);
            contact.IsDeleted = true;
            contact.DeletedBy = userEmail;
            contact.DeletedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Contact>().UpdateAsycn(contact);
            await _unitOfWork.SaveAsync();

            return contact.NameSurname;
        }
    }
}
/*
 
      public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
        {
            var userEmail = _user.GetLoggedInUserEmail(); //İlgili extensions metodunu çağırıp user mail yi çekiyoruz

            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Category>().UpdateAsycn(category);
            await unitOfWork.SaveAsync();
            return category.Name;
        }
 
 */