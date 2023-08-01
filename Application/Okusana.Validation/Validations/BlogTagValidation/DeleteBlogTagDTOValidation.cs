using FluentValidation;
using Okusana.DTOs.Concrete.BlogTag;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.BlogTagValidation
{
    public class DeleteBlogTagDTOValidation : AbstractValidator<DeleteBlogTagDTO>
    {
        public DeleteBlogTagDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
        }
    }
}
