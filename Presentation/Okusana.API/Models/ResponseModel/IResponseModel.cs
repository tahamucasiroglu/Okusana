using Okusana.API.Models.HateoasModel;
using Okusana.Returns.Abstract;

namespace Okusana.API.Models.ResponseModel
{
    public interface IResponse<T>
    {
        public string? ApiMessage { get; init; }
        public IReturnModel<T> Data { get; init; }
        public Hateoas Hateoas { get; init; }
    }
    public interface IResponse
    {
        public string? ApiMessage { get; init; }
        public Hateoas? Hateoas { get; init; }
    }
}
