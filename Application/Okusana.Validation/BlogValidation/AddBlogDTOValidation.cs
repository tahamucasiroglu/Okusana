using FluentValidation;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.BlogValidation
{
    public class AddBlogDTOValidation : AbstractValidator<AddBlogDTO>
    {
        public AddBlogDTOValidation()
        {
            RuleFor(c => c.UserId).Required("Blogu kim yazdı?").IsGuid("Id tipi Uyumsuz");
            RuleFor(c => c.SubCategoryId).Required("Blogun kategorisi ne?").IsGuid("Id tipi Uyumsuz");

        }
    }
}
