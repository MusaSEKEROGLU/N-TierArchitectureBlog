using FluentValidation;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Validations
{
	public class WriterValidator : AbstractValidator<Writer>
	{
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("Yazar Adınız-Soyadınız alanı boş geçilmemeli");
			RuleFor(w => w.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
			RuleFor(w => w.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız"); ;

			RuleFor(w => w.WriterMail).NotEmpty().WithMessage("Yazar Email Adresiniz alanı boş geçilmemeli");
			RuleFor(w => w.WriterMail).EmailAddress().WithMessage("Email Adresiniz doğru formatta değildir"); ;
			
			RuleFor(w => w.WriterPassword).NotEmpty().WithMessage("Yazar Şifreniz alanı boş geçilmemeli");			
		}
    }
}
