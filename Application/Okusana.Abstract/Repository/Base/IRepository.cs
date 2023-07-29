using Okusana.Entities.Abstract;
using Okusana.Extensions;
using Okusana.Returns.Abstract;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Okusana.Abstract.Repository.Base
{

    public interface IRepository<T> : IRepositoryCore<T> 
        where T : class, IEntity, new()
    {

        public IReturnModel<T> GetDeleted(Expression<Func<T, bool>> filter);
        public Task<IReturnModel<T>> GetDeletedAsync(Expression<Func<T, bool>> filter);

        public IReturnModel<IEnumerable<T>> _GetAllDeleted<TOrder>(Expression<Func<T, bool>>? filter = null, Expression<Func<T, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null);
        public IReturnModel<IEnumerable<T>> GetAllDeleted() => _GetAllDeleted<T>();
        public IReturnModel<IEnumerable<T>> GetAllDeleted(Range TakeRange) => _GetAllDeleted<T>(TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAllDeleted(bool Reserve) => _GetAllDeleted<T>(Reserve: Reserve);
        public IReturnModel<IEnumerable<T>> GetAllDeleted(bool Reserve, Range TakeRange) => _GetAllDeleted<T>(Reserve: Reserve, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAllDeleted<TOrder>(Expression<Func<T, TOrder>> order) => _GetAllDeleted<TOrder>(order: order);
        public IReturnModel<IEnumerable<T>> GetAllDeleted<TOrder>(Expression<Func<T, TOrder>> order, Range TakeRange) => _GetAllDeleted<TOrder>(order: order, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAllDeleted<TOrder>(Expression<Func<T, TOrder>> order, bool Reserve) => _GetAllDeleted<TOrder>(order: order, Reserve: Reserve);
        public IReturnModel<IEnumerable<T>> GetAllDeleted<TOrder>(Expression<Func<T, TOrder>> order, bool Reserve, Range TakeRange) => _GetAllDeleted<TOrder>(order: order, Reserve: Reserve, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAllDeleted(Expression<Func<T, bool>> filter) => _GetAllDeleted<T>(filter: filter);
        public IReturnModel<IEnumerable<T>> GetAllDeleted(Expression<Func<T, bool>> filter, Range TakeRange) => _GetAllDeleted<T>(filter: filter, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAllDeleted(Expression<Func<T, bool>> filter, bool Reserve) => _GetAllDeleted<T>(filter: filter, Reserve: Reserve);
        public IReturnModel<IEnumerable<T>> GetAllDeleted(Expression<Func<T, bool>> filter, bool Reserve, Range TakeRange) => _GetAllDeleted<T>(filter: filter, Reserve: Reserve, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAllDeleted<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order) => _GetAllDeleted<TOrder>(filter: filter, order: order);
        public IReturnModel<IEnumerable<T>> GetAllDeleted<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, Range TakeRange) => _GetAllDeleted<TOrder>(filter: filter, order: order, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAllDeleted<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, bool Reserve) => _GetAllDeleted<TOrder>(filter: filter, order: order, Reserve: Reserve);
        public IReturnModel<IEnumerable<T>> GetAllDeleted<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, bool Reserve, Range TakeRange) => _GetAllDeleted<TOrder>(filter: filter, order: order, Reserve: Reserve, TakeRange: TakeRange);


        public Task<IReturnModel<IEnumerable<T>>> _GetAllDeletedAsync<TOrder>(Expression<Func<T, bool>>? filter = null, Expression<Func<T, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync() => await _GetAllDeletedAsync<T>();
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync(Range TakeRange) => await _GetAllDeletedAsync<T>(TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync(bool Reserve) => await _GetAllDeletedAsync<T>(Reserve: Reserve);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync(bool Reserve, Range TakeRange) => await _GetAllDeletedAsync<T>(Reserve: Reserve, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync<TOrder>(Expression<Func<T, TOrder>> order) => await _GetAllDeletedAsync<TOrder>(order: order);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync<TOrder>(Expression<Func<T, TOrder>> order, Range TakeRange) => await _GetAllDeletedAsync<TOrder>(order: order, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync<TOrder>(Expression<Func<T, TOrder>> order, bool Reserve) => await _GetAllDeletedAsync<TOrder>(order: order, Reserve: Reserve);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync<TOrder>(Expression<Func<T, TOrder>> order, bool Reserve, Range TakeRange) => await _GetAllDeletedAsync<TOrder>(order: order, Reserve: Reserve, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync(Expression<Func<T, bool>> filter) => await _GetAllDeletedAsync<T>(filter: filter);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync(Expression<Func<T, bool>> filter, Range TakeRange) => await _GetAllDeletedAsync<T>(filter: filter, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync(Expression<Func<T, bool>> filter, bool Reserve) => await _GetAllDeletedAsync<T>(filter: filter, Reserve: Reserve);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync(Expression<Func<T, bool>> filter, bool Reserve, Range TakeRange) => await _GetAllDeletedAsync<T>(filter: filter, Reserve: Reserve, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order) => await _GetAllDeletedAsync<TOrder>(filter: filter, order: order);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, Range TakeRange) => await _GetAllDeletedAsync<TOrder>(filter: filter, order: order, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, bool Reserve) => await _GetAllDeletedAsync<TOrder>(filter: filter, order: order, Reserve: Reserve);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllDeletedAsync<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, bool Reserve, Range TakeRange) => await _GetAllDeletedAsync<TOrder>(filter: filter, order: order, Reserve: Reserve, TakeRange: TakeRange);

        public new IReturnModel<T> Delete(T entity);
        public new IReturnModel<IEnumerable<T>> Delete(IEnumerable<T> entity);
        public new Task<IReturnModel<T>> DeleteAsync(T entity);
        public new Task<IReturnModel<IEnumerable<T>>> DeleteAsync(IEnumerable<T> entity);

    }




    public interface IRepositoryCore<T> where T : class, IEntityCore, new()
    {
        public IReturnModel<T> Get(Expression<Func<T, bool>> filter);
        public Task<IReturnModel<T>> GetAsync(Expression<Func<T, bool>> filter);

        public IReturnModel<IEnumerable<T>> _GetAll<TOrder>(Expression<Func<T, bool>>? filter = null, Expression<Func<T, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null);
        public IReturnModel<IEnumerable<T>> GetAll() => _GetAll<T>();
        public IReturnModel<IEnumerable<T>> GetAll(Range TakeRange) => _GetAll<T>(TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAll(bool Reserve) => _GetAll<T>(Reserve: Reserve);
        public IReturnModel<IEnumerable<T>> GetAll(bool Reserve, Range TakeRange) => _GetAll<T>(Reserve: Reserve, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAll<TOrder>(Expression<Func<T, TOrder>> order) => _GetAll<TOrder>(order: order);
        public IReturnModel<IEnumerable<T>> GetAll<TOrder>(Expression<Func<T, TOrder>> order, Range TakeRange) => _GetAll<TOrder>(order: order, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAll<TOrder>(Expression<Func<T, TOrder>> order, bool Reserve) => _GetAll<TOrder>(order: order, Reserve: Reserve);
        public IReturnModel<IEnumerable<T>> GetAll<TOrder>(Expression<Func<T, TOrder>> order, bool Reserve, Range TakeRange) => _GetAll<TOrder>(order: order, Reserve: Reserve, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter) => _GetAll<T>(filter: filter);
        public IReturnModel<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, Range TakeRange) => _GetAll<T>(filter: filter, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, bool Reserve) => _GetAll<T>(filter: filter, Reserve: Reserve);
        public IReturnModel<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, bool Reserve, Range TakeRange) => _GetAll<T>(filter: filter, Reserve: Reserve, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAll<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order) => _GetAll<TOrder>(filter: filter, order: order);
        public IReturnModel<IEnumerable<T>> GetAll<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, Range TakeRange) => _GetAll<TOrder>(filter: filter, order: order, TakeRange: TakeRange);
        public IReturnModel<IEnumerable<T>> GetAll<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, bool Reserve) => _GetAll<TOrder>(filter: filter, order: order, Reserve: Reserve);
        public IReturnModel<IEnumerable<T>> GetAll<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, bool Reserve, Range TakeRange) => _GetAll<TOrder>(filter: filter, order: order, Reserve: Reserve, TakeRange: TakeRange);




        public Task<IReturnModel<IEnumerable<T>>> _GetAllAsync<TOrder>(Expression<Func<T, bool>>? filter = null, Expression<Func<T, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync() => await _GetAllAsync<T>();
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync(Range TakeRange) => await _GetAllAsync<T>(TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync(bool Reserve) => await _GetAllAsync<T>(Reserve: Reserve);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync(bool Reserve, Range TakeRange) => await _GetAllAsync<T>(Reserve: Reserve, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync<TOrder>(Expression<Func<T, TOrder>> order) => await _GetAllAsync<TOrder>(order: order);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync<TOrder>(Expression<Func<T, TOrder>> order, Range TakeRange) => await _GetAllAsync<TOrder>(order: order, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync<TOrder>(Expression<Func<T, TOrder>> order, bool Reserve) => await _GetAllAsync<TOrder>(order: order, Reserve: Reserve);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync<TOrder>(Expression<Func<T, TOrder>> order, bool Reserve, Range TakeRange) => await _GetAllAsync<TOrder>(order: order, Reserve: Reserve, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> filter) => await _GetAllAsync<T>(filter: filter);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> filter, Range TakeRange) => await _GetAllAsync<T>(filter: filter, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> filter, bool Reserve) => await _GetAllAsync<T>(filter: filter, Reserve: Reserve);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>> filter, bool Reserve, Range TakeRange) => await _GetAllAsync<T>(filter: filter, Reserve: Reserve, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order) => await _GetAllAsync<TOrder>(filter: filter, order: order);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, Range TakeRange) => await _GetAllAsync<TOrder>(filter: filter, order: order, TakeRange: TakeRange);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, bool Reserve) => await _GetAllAsync<TOrder>(filter: filter, order: order, Reserve: Reserve);
        public async Task<IReturnModel<IEnumerable<T>>> GetAllAsync<TOrder>(Expression<Func<T, bool>> filter, Expression<Func<T, TOrder>> order, bool Reserve, Range TakeRange) => await _GetAllAsync<TOrder>(filter: filter, order: order, Reserve: Reserve, TakeRange: TakeRange);

        public IReturnModel<int> Count(Expression<Func<T, bool>>? filter = null);
        public Task<IReturnModel<int>> CountAsync(Expression<Func<T, bool>>? filter = null);

        public IReturnModel<bool> IsExist(Expression<Func<T, bool>> filter);
        public Task<IReturnModel<bool>> IsExistAsync(Expression<Func<T, bool>> filter);

        public IReturnModel<T> Add(T entity);
        public IReturnModel<IEnumerable<T>> Add(IEnumerable<T> entity);
        public Task<IReturnModel<T>> AddAsync(T entity);
        public Task<IReturnModel<IEnumerable<T>>> AddAsync(IEnumerable<T> entity);

        public IReturnModel<T> Update(T entity);
        public IReturnModel<IEnumerable<T>> Update(IEnumerable<T> entity);
        public Task<IReturnModel<T>> UpdateAsync(T entity);
        public Task<IReturnModel<IEnumerable<T>>> UpdateAsync(IEnumerable<T> entity);

        public IReturnModel<T> Delete(T entity);
        public IReturnModel<IEnumerable<T>> Delete(IEnumerable<T> entity);
        public Task<IReturnModel<T>> DeleteAsync(T entity);
        public Task<IReturnModel<IEnumerable<T>>> DeleteAsync(IEnumerable<T> entity);

        public IReturnModel<T> Save(T entity);
        public IReturnModel<IEnumerable<T>> Save(IEnumerable<T> entity);
        public Task<IReturnModel<T>> SaveAsync(T entity);
        public Task<IReturnModel<IEnumerable<T>>> SaveAsync(IEnumerable<T> entity);

        public IReturnModel<TNull> CheckIsNull<TNull>(TNull? result);
    }
}
