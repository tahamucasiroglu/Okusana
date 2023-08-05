using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Abstract.Models.PaginationModel;
using Okusana.Abstract.Models.ResponseModel;
using Okusana.Returns.Abstract;

namespace Okusana.Models.ResponseModel
{
    public record Response<T> : Response, IResponse<T>
    {
        public IReturnModel<T> Data { get; init; }
        public Response(IReturnModel<T> data, string? apiMessage = null, IHateoas? hateoas = null, IPagination? pagination = null) : base(apiMessage, hateoas, pagination)
        {
            Data = data;
        }
    }

    public record Response : IResponse
    {
        public string? ApiMessage { get; init; }
        public IHateoas? Hateoas { get; init; }
        public IPagination? Pagination { get; init; }
        public Response(string? apiMessage = null, IHateoas? hateoas = null, IPagination? pagination = null)
        {
            ApiMessage = apiMessage;
            Hateoas = hateoas;
            Pagination = pagination;
        }
    }
}
