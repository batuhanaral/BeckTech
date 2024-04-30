using AutoMapper;
using BechTech.Entity.DTO.Articles;
using BechTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.AutoMapper.Articles
{
    public class ArticleProfile :Profile    
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<ArticleUpdateDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, ArticleDto>().ReverseMap();
            CreateMap<ArticleAddDto, Article>().ReverseMap();
            CreateMap<ArticleForUserDto, Article>().ReverseMap();
        }
    }
}
