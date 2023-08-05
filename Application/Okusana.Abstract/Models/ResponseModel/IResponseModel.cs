using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Abstract.Models.PaginationModel;
using Okusana.Returns.Abstract;

namespace Okusana.Abstract.Models.ResponseModel
{
    public interface IResponse<T> : IResponse
    {
        public IReturnModel<T> Data { get; init; }
    }
    public interface IResponse
    {
        public string? ApiMessage { get; init; }
        public IHateoas? Hateoas { get; init; }
        public IPagination? Pagination { get; init; }
    }
}
