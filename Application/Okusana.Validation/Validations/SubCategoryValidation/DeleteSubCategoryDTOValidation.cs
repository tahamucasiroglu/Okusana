using FluentValidation;
using Okusana.DTOs.Concrete.SubCategory;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.SubCategoryValidation
{
    public class DeleteSubCategoryDTOValidation : AbstractValidator<DeleteSubCategoryDTO>
    {
        public DeleteSubCategoryDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
        }
    }
}
