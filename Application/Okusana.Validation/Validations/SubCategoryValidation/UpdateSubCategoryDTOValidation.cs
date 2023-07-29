using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.SubCategory;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.SubCategoryValidation
{
    public class UpdateSubCategoryDTOValidation : AbstractValidator<UpdateSubCategoryDTO>
    {
        public UpdateSubCategoryDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
            RuleFor(e => e.CategoryId).Required(DbSettings.SubCategory.CategoryId.Required, "Nere ekleyem").IsGuid(DbSettings.NonGuidMessage);
            RuleFor(e => e.Name).MaximumLength(DbSettings.SubCategory.Name.Length).Required(DbSettings.SubCategory.Name.Required, "Adı ne bunun adı ne");
            RuleFor(e => e.Description).MaximumLength(DbSettings.SubCategory.Describtion.Length);
        }
    }
}
