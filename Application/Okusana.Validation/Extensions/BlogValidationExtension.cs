using FluentValidation;
using Okusana.Constants.DbSettingConstants;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Extensions;

namespace Okusana.Validation.Extensions
{
    static public class BlogValidationExtension
    {
        static public IRuleBuilderOptions<UpdateBlogDTO, Guid> IdValidation(this IRuleBuilderInitial<UpdateBlogDTO, Guid> validation)
            => validation.IdValidationBase();
        static public IRuleBuilderOptions<DeleteBlogDTO, Guid> IdValidation(this IRuleBuilderInitial<DeleteBlogDTO, Guid> validation)
            => validation.IdValidationBase();
        static public IRuleBuilderOptions<T, Guid> UserIdValidation<T>(this IRuleBuilderInitial<T, Guid> validation)
            => validation.Required(BlogDbSettingsConstant.BlogUserIdIsRequired, "Blogu kim yazdı?").IsGuid(BlogDbSettingsConstant.NonGuid);
        static public IRuleBuilderOptions<T, Guid> SubCategoryIdValidation<T>(this IRuleBuilderInitial<T, Guid> validation)
            => validation.Required(BlogDbSettingsConstant.BlogSubCategoryIdIsRequired, "Blogun kategorisi ne?").IsGuid(BlogDbSettingsConstant.NonGuid);
        static public IRuleBuilderOptions<T, string> TitleValidation<T>(this IRuleBuilderInitial<T, string> validation)
            => validation.MaximumLength(BlogDbSettingsConstant.BlogTitleLength).WithMessage($"Başlık {BlogDbSettingsConstant.BlogTitleLength} karakterden fazla olamaz").Required(BlogDbSettingsConstant.BlogTitleIsRequired, "Başlık olamadan blog eklenemez");
        static public IRuleBuilderOptions<T, string> ContentValidation<T>(this IRuleBuilderInitial<T, string> validation)
            => validation.MaximumLength(BlogDbSettingsConstant.BlogContentLength).WithMessage($"Başlık {BlogDbSettingsConstant.BlogContentLength} karakterden fazla olamaz").Required(BlogDbSettingsConstant.BlogContentIsRequired, "İçerik olmadan blog oluşturulamaz");
        static public IRuleBuilderOptions<T, DateTime?> PublicationDateValidation<T>(this IRuleBuilderInitial<T, DateTime?> validation)
            => validation.Must(e => e == null || e.IsBiggerThan(DateTime.Now));
    }
}
