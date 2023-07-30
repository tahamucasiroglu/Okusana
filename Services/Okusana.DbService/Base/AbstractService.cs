using AutoMapper;
using Okusana.Abstract.Repository.Base;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Abstract;
using Okusana.Entities.Abstract;
using Okusana.Returns.Abstract;
using Okusana.Returns.Concrete;
using Okusana.Mapper.Extensions;
using Okusana.Extensions;

namespace Okusana.DbService.Base
{
    abstract public class AbstractService : IService
    {
        /// <summary>
        /// Tüm servis dönüşlerini kontrol etmek ve kolayca dönüştürmek için kullanılan yardımcı bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüştürülecek DTO tipini belirten IDto türetilmiş sınıf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiş sınıf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüştürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüşümünde kullanılacak IMapper nesnesi.</param> 
        /// <returns>Dönüştürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IReturnModel<TCheck> ConvertToReturn<TCheck, TEntity>(IReturnModel<TEntity> result, IMapper mapper)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null
                    ? new SuccessReturnModel<TCheck>("Data is null")
                    : new SuccessReturnModel<TCheck>(result.Data.ConvertToDtoCustom<TCheck>(mapper));
            }
            else
            {
                return new ErrorReturnModel<TCheck>(result.Message, null, result.Exception);
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
        public virtual IReturnModel<IEnumerable<TCheck>> ConvertToReturn<TCheck, TEntity>(IReturnModel<IEnumerable<TEntity>> result, IMapper mapper)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<IEnumerable<TCheck>>("Data is null") :
                    new SuccessReturnModel<IEnumerable<TCheck>>(result.Data.ConvertToDtoCustom<TCheck>(mapper));
            }
            else
            {
                return new ErrorReturnModel<IEnumerable<TCheck>>(result.Message, null, result.Exception);
            }
        }
    }
    abstract public class AbstractService<TEntity> : AbstractService
        where TEntity : class, IEntity, new()
    {
        internal readonly IRepository<TEntity> repository;
        internal readonly IMapper mapper;
        public AbstractService(IRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
    }
    abstract public class AbstractService<TEntity, Response> : AbstractService<TEntity>, IService<Response>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper) { }
        public virtual IReturnModel<IEnumerable<Response>> GetAll()
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.GetAll();
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }

        public virtual async Task<IReturnModel<IEnumerable<Response>>> GetAllAsync()
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.GetAllAsync();
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }
    }
    abstract public class AbstractService<TEntity, Response, AddRequest> : AbstractService<TEntity, Response>, IService<Response, AddRequest>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
        where AddRequest : class, IAddDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper) { }

        public virtual IReturnModel<Response> Add(AddRequest entity)
        {
            IReturnModel<TEntity> result = repository.Add(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }

        public virtual IReturnModel<IEnumerable<Response>> Add(IEnumerable<AddRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.Add(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }

        public virtual async Task<IReturnModel<Response>> AddAsync(AddRequest entity)
        {
            IReturnModel<TEntity> result = await repository.AddAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }

        public virtual async Task<IReturnModel<IEnumerable<Response>>> AddAsync(IEnumerable<AddRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.AddAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }

        public virtual IReturnModel<Response> Delete(Guid entity)
        {
            IReturnModel<TEntity> result = repository.Get(e => e.Id == entity);
            if(result.Status && result.Data != null) 
            {
                TEntity data = result.Data;
                data.IsDeleted = true;
                return ConvertToReturn<Response, TEntity>(repository.Update(data), mapper);
            }
            else
            {
                return new ErrorReturnModel<Response>();
            }
        }

        public virtual IReturnModel<IEnumerable<Response>> Delete(IEnumerable<Guid> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.GetAll(e => entity.Any(x => x == e.Id));
            if (result.Status && result.Data != null)
            {
                IEnumerable<TEntity> data = result.Data;
                data = data.ChangeAll(e => e.IsDeleted = true);
                return ConvertToReturn<Response, TEntity>(repository.Update(data), mapper);
            }
            else
            {
                return new ErrorReturnModel<IEnumerable<Response>>();
            }
        }

        public virtual async Task<IReturnModel<Response>> DeleteAsync(Guid entity)
        {
            IReturnModel<TEntity> result = await repository.GetAsync(e => e.Id == entity);
            if (result.Status && result.Data != null)
            {
                TEntity data = result.Data;
                data.IsDeleted = true;
                return ConvertToReturn<Response, TEntity>(await repository.UpdateAsync(data), mapper);
            }
            else
            {
                return new ErrorReturnModel<Response>();
            }
        }

        public virtual async Task<IReturnModel<IEnumerable<Response>>> DeleteAsync(IEnumerable<Guid> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.GetAllAsync(e => entity.Any(x => x == e.Id));
            if (result.Status && result.Data != null)
            {
                IEnumerable<TEntity> data = result.Data;
                data = data.ChangeAll(e => e.IsDeleted = true);
                return ConvertToReturn<Response, TEntity>(await repository.UpdateAsync(data), mapper);
            }
            else
            {
                return new ErrorReturnModel<IEnumerable<Response>>();
            }
        }
    }

    abstract public class AbstractService<TEntity, Response, AddRequest, UpdateRequest> : AbstractService<TEntity, Response, AddRequest>, IService<Response, AddRequest, UpdateRequest>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
        where AddRequest : class, IAddDTO
        where UpdateRequest : class, IUpdateDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper) : base(repository, mapper) { }

        public virtual IReturnModel<Response> Update(UpdateRequest entity)
        {
            IReturnModel<TEntity> result = repository.Update(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }

        public virtual IReturnModel<IEnumerable<Response>> Update(IEnumerable<UpdateRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.Update(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }

        public virtual async Task<IReturnModel<Response>> UpdateAsync(UpdateRequest entity)
        {
            IReturnModel<TEntity> result = await repository.UpdateAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }

        public virtual async Task<IReturnModel<IEnumerable<Response>>> UpdateAsync(IEnumerable<UpdateRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.UpdateAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper);
        }
    }


}
