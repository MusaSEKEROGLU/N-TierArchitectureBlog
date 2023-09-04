using FluentValidation;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Validations
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(w => w.BlogTitle).NotEmpty().WithMessage("Blog başlık alanı boş geçilmemeli");
            RuleFor(w => w.BlogTitle).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız");
            RuleFor(w => w.BlogTitle).MaximumLength(150).WithMessage("Lütfen en fazla 150 karakter girişi yapınız"); ;
            RuleFor(w => w.BlogContent).NotEmpty().WithMessage("Blog içeriği alanı boş geçilmemeli");
            RuleFor(w => w.BlogImage).NotEmpty().WithMessage("Lütfen blog resmini ekleyiniz"); ;
        }
    }
}
