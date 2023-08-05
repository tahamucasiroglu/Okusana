using AutoMapper;
using Okusana.Abstract.Repository.Base;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Abstract;
using Okusana.Entities.Abstract;
using Okusana.Returns.Abstract;
using Okusana.Returns.Concrete;
using Okusana.Mapper.Extensions;
using Okusana.Extensions;
using Microsoft.AspNetCore.Mvc;
using Okusana.Models.ResponseModel;
using Okusana.Abstract.Models.PaginationModel;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Models.HateoasModel;

namespace Okusana.DbService.Base
{
    abstract public class AbstractService : IService
    {
        private IActionResult EmptyDataReturn<TCheck, TEntity>(string? Message = null, IHateoas? IHateoas = null, IPagination? pagination = null) => new OkObjectResult(new Response<TCheck>(new SuccessReturnModel<TCheck>("Data is null " + Message), "Başarıyla döndürme sağlandı fakat data null", IHateoas, pagination));
        
        private IActionResult ErrorDataReturn<TCheck>(string? Message = null, Exception? exception = null) => new BadRequestObjectResult(new Response<IEnumerable<TCheck>>(new ErrorReturnModel<IEnumerable<TCheck>>(Message, null, exception)));


        /// <summary>
        /// Tüm servis dönüşlerini kontrol etmek ve kolayca dönüştürmek için kullanılan yardımcı bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüştürülecek DTO tipini belirten IDto türetilmiş sınıf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiş sınıf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüştürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüşümünde kullanılacak IMapper nesnesi.</param> 
        /// <returns>Dönüştürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IActionResult ConvertToReturn<TCheck, TEntity>(IReturnModel<TEntity> result, IMapper mapper, IHateoas? hateoas = null, IPagination? pagination = null)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            Console.WriteLine(hateoas);
            if (result.Status)
            {
                return result.Data == null ?
                    EmptyDataReturn<TCheck, TEntity>(result.Message, hateoas, pagination) :
                    new OkObjectResult(new Response<TCheck>(new SuccessReturnModel<TCheck>("Data not null " + result.Message, result.Data.ConvertToDtoCustom<TCheck>(mapper)), "Başarıyla döndürme sağlandı data null değil", hateoas, pagination));
            }
            else
            {
                return ErrorDataReturn<TCheck>(result.Message, result.Exception);
            }
        }
        /// <summary>
        /// Tüm servis dönüşlerini kontrol etmek ve kolayca dönüştürmek için kullanılan yardımcı bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüştürülecek DTO tipini belirten IDto türetilmiş sınıf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiş sınıf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüştürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüşümünde kullanılacak IMapper nesnesi.</param> 
        /// <returns>Dönüştürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IActionResult ConvertToReturn<TCheck, TEntity>(IReturnModel<IEnumerable<TEntity>> result, IMapper mapper, IHateoas? hateoas = null, IPagination? pagination = null)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            Console.WriteLine(hateoas);
            if (result.Status)
            {
                return result.Data == null ?
                    EmptyDataReturn<TCheck, TEntity>(result.Message, hateoas, pagination) :
                    new OkObjectResult(new Response<IEnumerable<TCheck>>(new SuccessReturnModel<IEnumerable<TCheck>>("Data not null " + result.Message, result.Data.ConvertToDtoCustom<TCheck>(mapper)), "Başarıyla döndürme sağlandı data null değil", hateoas, pagination));
            }
            else
            {
                return ErrorDataReturn<TCheck>(result.Message, result.Exception);
            }
        }

        public virtual IActionResult ReturnEmptyError<T>(string? Message = null) => new BadRequestObjectResult(new ErrorReturnModel<T>(Message));

    }
    abstract public class AbstractService<TEntity> : AbstractService
        where TEntity : class, IEntity, new()
    {
        internal readonly IRepository<TEntity> repository;
        internal readonly IMapper mapper;
        internal readonly IHateoas hateoas;
        public AbstractService(IRepository<TEntity> repository, IMapper mapper, IHateoas hateoas)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.hateoas = hateoas;
        }
    }
    abstract public class AbstractService<TEntity, Response> : AbstractService<TEntity>, IService<Response>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper, IHateoas hateoas) : base(repository, mapper, hateoas) { }
        public virtual IActionResult GetAll()
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.GetAll();
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> GetAllAsync()
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.GetAllAsync();
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }
    }
    abstract public class AbstractService<TEntity, Response, AddRequest> : AbstractService<TEntity, Response>, IService<Response, AddRequest>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
        where AddRequest : class, IAddDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper, IHateoas hateoas) : base(repository, mapper, hateoas) { }

        public virtual IActionResult Add(AddRequest entity)
        {
            IReturnModel<TEntity> result = repository.Add(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual IActionResult Add(IEnumerable<AddRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.Add(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> AddAsync(AddRequest entity)
        {
            IReturnModel<TEntity> result = await repository.AddAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> AddAsync(IEnumerable<AddRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.AddAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual IActionResult Delete(Guid entity)
        {
            IReturnModel<TEntity> result = repository.Get(e => e.Id == entity);
            if(result.Status && result.Data != null) 
            {
                TEntity data = result.Data;
                data.IsDeleted = true;
                return ConvertToReturn<Response, TEntity>(repository.Update(data), mapper, hateoas);
            }
            else
            {
                return ReturnEmptyError<Response>();
            }
        }

        public virtual IActionResult Delete(IEnumerable<Guid> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.GetAll(e => entity.Any(x => x == e.Id));
            if (result.Status && result.Data != null)
            {
                IEnumerable<TEntity> data = result.Data;
                data = data.ChangeAll(e => e.IsDeleted = true);
                return ConvertToReturn<Response, TEntity>(repository.Update(data), mapper, hateoas);
            }
            else
            {
                return ReturnEmptyError<Response>();
            }
        }

        public virtual async Task<IActionResult> DeleteAsync(Guid entity)
        {
            IReturnModel<TEntity> result = await repository.GetAsync(e => e.Id == entity);
            if (result.Status && result.Data != null)
            {
                TEntity data = result.Data;
                data.IsDeleted = true;
                return ConvertToReturn<Response, TEntity>(await repository.UpdateAsync(data), mapper, hateoas);
            }
            else
            {
                return ReturnEmptyError<Response>();
            }
        }

        public virtual async Task<IActionResult> DeleteAsync(IEnumerable<Guid> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.GetAllAsync(e => entity.Any(x => x == e.Id));
            if (result.Status && result.Data != null)
            {
                IEnumerable<TEntity> data = result.Data;
                data = data.ChangeAll(e => e.IsDeleted = true);
                return ConvertToReturn<Response, TEntity>(await repository.UpdateAsync(data), mapper, hateoas);
            }
            else
            {
                return ReturnEmptyError<Response>();
            }
        }
    }

    abstract public class AbstractService<TEntity, Response, AddRequest, UpdateRequest> : AbstractService<TEntity, Response, AddRequest>, IService<Response, AddRequest, UpdateRequest>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
        where AddRequest : class, IAddDTO
        where UpdateRequest : class, IUpdateDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper, IHateoas hateoas) : base(repository, mapper, hateoas) { }

        public virtual IActionResult Update(UpdateRequest entity)
        {
            IReturnModel<TEntity> result = repository.Update(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual IActionResult Update(IEnumerable<UpdateRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.Update(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> UpdateAsync(UpdateRequest entity)
        {
            IReturnModel<TEntity> result = await repository.UpdateAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> UpdateAsync(IEnumerable<UpdateRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.UpdateAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }
    }


}
