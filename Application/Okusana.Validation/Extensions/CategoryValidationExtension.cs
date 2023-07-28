using FluentValidation;
using Okusana.Constants.DbSettingConstants;
using Okusana.DTOs.Concrete.Category;

namespace Okusana.Validation.Extensions
{
    static public class CategoryValidationExtension
    {
        static public IRuleBuilderOptions<DeleteCategoryDTO, Guid> IdValidation(this IRuleBuilderInitial<DeleteCategoryDTO, Guid> validation)
            => validation.IdValidationBase();
        static public IRuleBuilderOptions<UpdateCategoryDTO, Guid> IdValidation(this IRuleBuilderInitial<UpdateCategoryDTO, Guid> validation)
            => validation.IdValidationBase();
        static public IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilderInitial<T, string> validation)
            => validation.MaximumLength(CategoryDbSettingsConstant.CategoryNameLength).WithMessage($"Adı {CategoryDbSettingsConstant.CategoryNameLength} karakterden fazla olamaz").Required(CategoryDbSettingsConstant.CategoryNameRequired, "Başlık olamadan kategory eklenemez");
        static public IRuleBuilderOptions<T, string?> DescriptionValidation<T>(this IRuleBuilderInitial<T, string?> validation)
            => validation.MaximumLength(CategoryDbSettingsConstant.CategoryDescriptionLength).WithMessage($"Başlık {CategoryDbSettingsConstant.CategoryDescriptionLength} karakterden fazla olamaz");
    }
}
