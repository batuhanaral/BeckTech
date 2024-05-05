using BechTech.Entity.DTO.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.Services.Abstractions
{
    public interface IVisitorService
    {
        Task<ArticleForUserDto> AddVisitor(Guid id);
    }
}
