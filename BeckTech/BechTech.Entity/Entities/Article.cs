using BeckTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BechTech.Entity.Entities
{

    public class Article : EntityBase
    {
        public Article()
        {
            
        }
        public Article(string title, string content, Guid userId, string createdBy, Guid categoriId, Guid imageId)
        {
            Title = title;
            Content = content;
            UserId = userId;
            ImageId = imageId;
            CategoryId = categoriId;
            CreatedBy = createdBy;

        }
      
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;
        public Guid CategoryId { get; set; }
        public Guid? ImageId { get; set; }
        public Guid UserId { get; set; }




        public Category Category { get; set; }
        public Image Image { get; set; }
        public AppUser User { get; set; }
        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }

    }
}
