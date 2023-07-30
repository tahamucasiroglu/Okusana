using Okusana.API.Models.HateoasModel;
using Okusana.Returns.Abstract;

namespace Okusana.API.Models.ResponseModel
{
    public sealed record Response<T> : IResponse<T>
    {
        public string? ApiMessage { get; init; }
        public IReturnModel<T> Data { get; init; }
        public Hateoas Hateoas { get; init; }
        public Response(string? apiMessage, IReturnModel<T> data, Hateoas hateoas)
        {
            ApiMessage = apiMessage;
            Data = data;
            Hateoas = hateoas;
        }
    }

    public sealed record Response : IResponse
    {
        public string? ApiMessage { get; init; }
        public Hateoas? Hateoas { get; init; }
        public Response(string? apiMessage, Hateoas? hateoas)
        {
            ApiMessage = apiMessage;
            Hateoas = hateoas;
        }
    }
}
