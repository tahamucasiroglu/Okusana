using Okusana.Abstract.Models.HateoasModel;
using Okusana.DTOs.Concrete.Comment;
using Okusana.Extensions;

namespace Okusana.Models.HateoasModel
{
    public partial record Hateoas
    {
        public record Comment : ICommentHateoas
        {
            public Dictionary<string, List<string>> Links
            {
                get => new Dictionary<string, List<string>>()
            {
                    {Hateoas.Methods.Get, new List<string>() { "/Comment/{Id}", "/Comment/{CategoryId}", "/Comment/{Date}" } },
                    {Hateoas.Methods.Post,  new List<string>{ $"/{nameof(AddCommentDTO)}"} },
                    {Hateoas.Methods.Put, new List<string>{ $"/{nameof(UpdateCommentDTO)}" } },
                    {Hateoas.Methods.Delete, new List<string>{ $"/{nameof(DeleteCommentDTO)}" } },
            };
            }
            public Dictionary<string, Dictionary<string, string>> Methods
            {
                get => new Dictionary<string, Dictionary<string, string>>()
            {
                    {Hateoas.Methods.Get, typeof(GetCommentDTO).GetPropertyDict() },
                    {Hateoas.Methods.Post, typeof(AddCommentDTO).GetPropertyDict() },
                    {Hateoas.Methods.Put, typeof(UpdateCommentDTO).GetPropertyDict() },
                    {Hateoas.Methods.Delete, typeof(DeleteCommentDTO).GetPropertyDict() },
            };
            }
        }
    }
}
