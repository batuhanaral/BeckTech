using BechTech.Entity.DTO.Articles;
using BechTech.Entity.DTO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Abstractions
{
    public interface IContactService
    {
        Task<bool> CreateContacteAsync(ContactDto contactDto);
        Task<List<ContactDto>> GetAllContactNonDeletedAsync();
        Task<ContactDto> GetContactNonDeletedAsync(Guid contactId);
        Task<string> SafeDeleteContactAsync(Guid contactId);

    }
}
