using BechTech.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckTech.Service.FluentValidations
{
    public  class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(500)
                .WithName("Mesaj");

            RuleFor(x => x.Subject)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
               .MaximumLength(500)
                .WithName("Konu");

            RuleFor(x => x.Email)
              .NotEmpty()
              .NotNull()
              .MinimumLength(5)
             .MaximumLength(30)
              .WithName("Emal");

            RuleFor(x => x.NameSurname)
             .NotEmpty()
             .NotNull()
             .MinimumLength(5)
            .MaximumLength(100)
             .WithName("Ad Soyad");

        }
    }
}
