using AutoMapper;
using BechTech.Entity.DTO.Article;
using BechTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.AutoMapper
{
    public class ArticleProfile :Profile    
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
        }
    }
}
