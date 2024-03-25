using BechTech.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.FluentValidations
{
    public class ArticleValidator :AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(150)
                .WithName("Başlık");

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .WithName("İçerik");


        }
    }
}
