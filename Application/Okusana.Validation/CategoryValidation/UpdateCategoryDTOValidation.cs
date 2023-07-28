using FluentValidation;
using Okusana.DTOs.Concrete.Category;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.CategoryValidation
{
    public class UpdateCategoryDTOValidation : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
            RuleFor(e => e.Name).NameValidation();
            RuleFor(e => e.Description).DescriptionValidation();
        }
    }
}
