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
        public IReturnModel<IEnumerable<Response>> GetAll();
        public Task<IReturnModel<IEnumerable<Response>>> GetAllAsync();
    }

    public interface _IServiceAdd<Response, in AddRequest>
    {
        public IReturnModel<Response> Add(AddRequest entity);
        public IReturnModel<IEnumerable<Response>> Add(IEnumerable<AddRequest> entity);
        public Task<IReturnModel<Response>> AddAsync(AddRequest entity);
        public Task<IReturnModel<IEnumerable<Response>>> AddAsync(IEnumerable<AddRequest> entity);
    }

    public interface _IServiceUpdate<Response, in UpdateRequest>
    {
        public IReturnModel<Response> Update(UpdateRequest entity);
        public IReturnModel<IEnumerable<Response>> Update(IEnumerable<UpdateRequest> entity);
        public Task<IReturnModel<Response>> UpdateAsync(UpdateRequest entity);
        public Task<IReturnModel<IEnumerable<Response>>> UpdateAsync(IEnumerable<UpdateRequest> entity);
    }
    public interface _IServiceDelete<Response>
    {
        public IReturnModel<Response> Delete(int entity);
        public IReturnModel<IEnumerable<Response>> Delete(IEnumerable<int> entity);
        public Task<IReturnModel<Response>> DeleteAsync(int entity);
        public Task<IReturnModel<IEnumerable<Response>>> DeleteAsync(IEnumerable<int> entity);
    }
}
