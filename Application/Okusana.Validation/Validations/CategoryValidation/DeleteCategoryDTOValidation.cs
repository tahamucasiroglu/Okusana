﻿using FluentValidation;
using Okusana.DTOs.Concrete.Category;
using Okusana.Validation.Extensions;

namespace Okusana.Validation.Validations.CategoryValidation
{
    public class DeleteCategoryDTOValidation : AbstractValidator<DeleteCategoryDTO>
    {
        public DeleteCategoryDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
        }
    }
}
