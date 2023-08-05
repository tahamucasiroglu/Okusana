using Okusana.Abstract.Models.HateoasModel;
using Okusana.DTOs.Concrete.Blog;
using Okusana.Extensions;

namespace Okusana.Models.HateoasModel
{

    public partial record Hateoas
    {
        public record Blog : IBlogHateoas
        {
            
            public Dictionary<string, List<string>> Links
            {
                get => new Dictionary<string, List<string>>()
            {
                    {Hateoas.Methods.Get, new List<string>() { "/Blog/{Id}", "/Blog/{CategoryId}", "/Blog/{Date}" } },
                    {Hateoas.Methods.Post,  new List<string>{ $"/Blog/Add/{nameof(AddBlogDTO)}"} },
                    {Hateoas.Methods.Put, new List<string>{ $"/Blog/Update{nameof(UpdateBlogDTO)}" } },
                    {Hateoas.Methods.Delete, new List<string>{ $"/Blog/Delete/{nameof(DeleteBlogDTO)}" } },
            };
            }
            public Dictionary<string, Dictionary<string, string>> Methods
            {
                get => new Dictionary<string, Dictionary<string, string>>()
            {
                    {Hateoas.Methods.Get, typeof(GetBlogDTO).GetPropertyDict() },
                    {Hateoas.Methods.Post, typeof(AddBlogDTO).GetPropertyDict() },
                    {Hateoas.Methods.Put, typeof(UpdateBlogDTO).GetPropertyDict() },
                    {Hateoas.Methods.Delete, typeof(DeleteBlogDTO).GetPropertyDict() },
            };
            }
        }
    }
}
