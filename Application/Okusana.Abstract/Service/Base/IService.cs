using Microsoft.AspNetCore.Mvc;
using Okusana.DTOs.Abstract;
using Okusana.Returns.Abstract;


namespace Okusana.Abstract.Service.Base
{
    public interface IService<Response, AddRequest, UpdateRequest> : IService<Response, AddRequest>, _IServiceUpdate<Response, UpdateRequest>, IService
        where Response : class, IGetDTO
        where AddRequest : class, IAddDTO
        where UpdateRequest : class, IUpdateDTO
    { }

    public interface IService<Response> : _IServiceGetAll<Response>, IService
        where Response : class, IGetDTO
    { }

    public interface IService<Response, AddRequest> : IService<Response>, _IServiceAdd<Response, AddRequest>, _IServiceDelete<Response>, IService
        where Response : class, IGetDTO
        where AddRequest : class, IAddDTO
    { }

    public interface IService //marker
    { }

    public interface _IServiceGetAll<Response> where Response : class, IGetDTO
    {
        public IActionResult GetAll();
        public Task<IActionResult> GetAllAsync();
    }

    public interface _IServiceAdd<Response, in AddRequest>
    {
        public IActionResult Add(AddRequest entity);
        public IActionResult Add(IEnumerable<AddRequest> entity);
        public Task<IActionResult> AddAsync(AddRequest entity);
        public Task<IActionResult> AddAsync(IEnumerable<AddRequest> entity);
    }

    public interface _IServiceUpdate<Response, in UpdateRequest>
    {
        public IActionResult Update(UpdateRequest entity);
        public IActionResult Update(IEnumerable<UpdateRequest> entity);
        public Task<IActionResult> UpdateAsync(UpdateRequest entity);
        public Task<IActionResult> UpdateAsync(IEnumerable<UpdateRequest> entity);
    }
    public interface _IServiceDelete<Response>
    {
        public IActionResult Delete(Guid entity);
        public IActionResult Delete(IEnumerable<Guid> entity);
        public Task<IActionResult> DeleteAsync(Guid entity);
        public Task<IActionResult> DeleteAsync(IEnumerable<Guid> entity);
    }
}
