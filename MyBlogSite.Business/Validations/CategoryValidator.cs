using FluentValidation;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(w => w.CategoryName).NotEmpty().WithMessage("Kategori adı alanı boş geçilmemeli");
            RuleFor(w => w.CategoryName).MaximumLength(150).WithMessage("Lütfen en fazla 150 karakter girişi yapınız");
            RuleFor(w => w.CategoryName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            
            RuleFor(w => w.CategoryDescription).NotEmpty().WithMessage("Kategori açıklama alanı boş geçilmemeli");                                                        
        }
    }
}
