using Okusana.Abstract.Models.HateoasModel;
using Okusana.DTOs.Concrete.Category;
using Okusana.Extensions;

namespace Okusana.Models.HateoasModel
{
    public partial record Hateoas
    {
        public record Category : ICategoryHateoas
        {
            public Dictionary<string, List<string>> Links
            {
                get => new Dictionary<string, List<string>>()
            {
                    {Hateoas.Methods.Get, new List<string>() { "/Category/{Id}", "/Category/{CategoryId}", "/Category/{Date}" } },
                    {Hateoas.Methods.Post,  new List<string>{ $"/{nameof(AddCategoryDTO)}"} },
                    {Hateoas.Methods.Put, new List<string>{ $"/{nameof(UpdateCategoryDTO)}" } },
                    {Hateoas.Methods.Delete, new List<string>{ $"/{nameof(DeleteCategoryDTO)}" } },
            };
            }
            public Dictionary<string, Dictionary<string, string>> Methods
            {
                get => new Dictionary<string, Dictionary<string, string>>()
            {
                    {Hateoas.Methods.Get, typeof(GetCategoryDTO).GetPropertyDict() },
                    {Hateoas.Methods.Post, typeof(AddCategoryDTO).GetPropertyDict() },
                    {Hateoas.Methods.Put, typeof(UpdateCategoryDTO).GetPropertyDict() },
                    {Hateoas.Methods.Delete, typeof(DeleteCategoryDTO).GetPropertyDict() },
            };
            }
        }
    }
}
