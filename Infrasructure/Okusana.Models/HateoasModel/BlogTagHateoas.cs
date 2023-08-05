using Okusana.Abstract.Models.HateoasModel;
using Okusana.DTOs.Concrete.BlogTag;
using Okusana.Extensions;

namespace Okusana.Models.HateoasModel
{
    public partial record Hateoas
    {
        public record BlogTag : IBlogTagHateoas
        {
            public Dictionary<string, List<string>> Links
            {
                get => new Dictionary<string, List<string>>()
            {
                    {Hateoas.Methods.Get, new List<string>() { "/BlogTag/{Id}", "/BlogTag/{CategoryId}", "/BlogTag/{Date}" } },
                    {Hateoas.Methods.Post,  new List<string>{ $"/{nameof(AddBlogTagDTO)}"} },
                    {Hateoas.Methods.Put, new List<string>{ $"/{nameof(UpdateBlogTagDTO)}" } },
                    {Hateoas.Methods.Delete, new List<string>{ $"/{nameof(DeleteBlogTagDTO)}" } },
            };
            }
            public Dictionary<string, Dictionary<string, string>> Methods
            {
                get => new Dictionary<string, Dictionary<string, string>>()
            {
                    {Hateoas.Methods.Get, typeof(GetBlogTagDTO).GetPropertyDict() },
                    {Hateoas.Methods.Post, typeof(AddBlogTagDTO).GetPropertyDict() },
                    {Hateoas.Methods.Put, typeof(UpdateBlogTagDTO).GetPropertyDict() },
                    {Hateoas.Methods.Delete, typeof(DeleteBlogTagDTO).GetPropertyDict() },
            };
            }
        }
    }
}
