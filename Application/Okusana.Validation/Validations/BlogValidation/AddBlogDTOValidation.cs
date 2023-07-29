using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Validation.Extensions;
using Okusana.Extensions;

namespace Okusana.Validation.Validations.BlogValidation
{
    public class AddBlogDTOValidation : AbstractValidator<AddBlogDTO>
    {
        public AddBlogDTOValidation()
        {
            RuleFor(e => e.UserId).Required(DbSettings.Blog.UserId.Required, "Blogu kim yazdı?").IsGuid(DbSettings.NonGuidMessage);
            RuleFor(e => e.SubCategoryId).Required(DbSettings.Blog.SubCategoryId.Required, "Blogun kategorisi ne?").IsGuid(DbSettings.NonGuidMessage);
            RuleFor(e => e.Title).MaximumLength(DbSettings.Blog.Title.Length).WithMessage($"Başlık {DbSettings.Blog.Title.Length} karakterden fazla olamaz").Required(DbSettings.Blog.Title.Required, "Başlık olamadan blog eklenemez");
            RuleFor(e => e.Content).MaximumLength(DbSettings.Blog.Content.Length).WithMessage($"Başlık {DbSettings.Blog.Content.Length} karakterden fazla olamaz").Required(DbSettings.Blog.Content.Required, "İçerik olmadan blog oluşturulamaz");
            RuleFor(e => e.PublicationDate).Must(e => e == null || e.IsBiggerThan(DateTime.Now));
        }
    }
}
