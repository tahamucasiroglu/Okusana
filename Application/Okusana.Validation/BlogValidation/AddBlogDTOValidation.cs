﻿using FluentValidation;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Validation.Extensions;


namespace Okusana.Validation.BlogValidation
{
    public class AddBlogDTOValidation : AbstractValidator<AddBlogDTO>
    {
        public AddBlogDTOValidation()
        {
            RuleFor(e => e.UserId).UserIdValidation();
            RuleFor(e => e.SubCategoryId).SubCategoryIdValidation();
            RuleFor(e => e.Title).TitleValidation();
            RuleFor(e => e.Content).ContentValidation();
            RuleFor(e => e.PublicationDate).PublicationDateValidation();
        }
    }
}
