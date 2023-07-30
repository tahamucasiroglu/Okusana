using Okusana.DTOs.Concrete.SubCategory;
using Okusana.Extensions;

namespace Okusana.API.Models.HateoasModel
{
    public partial record Hateoas
    {
        public record SubCategory
        {
            public Dictionary<string, List<string>> Links
            {
                get => new Dictionary<string, List<string>>()
            {
                {Hateoas.Methods.Get, new List<string>() { "/SubCategory/{Id}", "/SubCategory/{CategoryId}", "/SubCategory/{Date}" } },
                {Hateoas.Methods.Post,  new List<string>{ $"/{nameof(AddSubCategoryDTO)}"} },
                {Hateoas.Methods.Put, new List<string>{ $"/{nameof(UpdateSubCategoryDTO)}" } },
                {Hateoas.Methods.Delete, new List<string>{ $"/{nameof(DeleteSubCategoryDTO)}" } },
            };
            }
            public Dictionary<string, Dictionary<string, string>> Methods
            {
                get => new Dictionary<string, Dictionary<string, string>>()
            {
                {Hateoas.Methods.Get, typeof(GetSubCategoryDTO).GetPropertyDict() },
                {Hateoas.Methods.Post, typeof(AddSubCategoryDTO).GetPropertyDict() },
                {Hateoas.Methods.Put, typeof(UpdateSubCategoryDTO).GetPropertyDict() },
                {Hateoas.Methods.Delete, typeof(DeleteSubCategoryDTO).GetPropertyDict() },
            };
                
            }
        }
    }
}
