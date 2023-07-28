using Okusana.Entities.Abstract;
using Okusana.Returns.Abstract;
using System.Linq.Expressions;

namespace Okusana.Abstract.Repository.Base
{
    public interface IRepository<T> where T : class, IEntity, new()
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

    }
}
