using Microsoft.EntityFrameworkCore;
using Okusana.Abstract.Repository.Base;
using Okusana.Entities.Abstract;
using Okusana.Extensions;
using Okusana.Returns.Abstract;
using Okusana.Returns.Concrete;
using System.Linq.Expressions;

namespace Okusana.Infrasructure.Repository.Base
{
    abstract public class AbstractRepository<TEntity, TContext> : AbstractRepositoryCore<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public AbstractRepository(TContext context) : base(context)
        {
        }

        public IReturnModel<TEntity> GetDeleted(Expression<Func<TEntity, bool>> filter)
        {
            var result = context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<TEntity>> GetDeletedAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = await context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }

        public IReturnModel<IEnumerable<TEntity>> _GetAllDeleted<TOrder>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null)
        {
            IQueryable<TEntity> result = context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking();
            if (filter != null) result = result.Where(filter);
            if (order != null) result = result.OrderBy(order);
            if (TakeRange != null) result = result.Take((Range)TakeRange);
            if (Reserve) result = result.Reverse();
            return new SuccessReturnModel<IEnumerable<TEntity>>("Başarıyla Getirildi", result);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> _GetAllDeletedAsync<TOrder>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null)
        {
            //zoraki async
            IQueryable<TEntity> result = context.Set<TEntity>().IgnoreQueryFilters().AsNoTracking();
            if (filter != null) result = result.Where(filter);
            if (order != null) result = result.OrderBy(order);
            if (TakeRange != null) result = result.Take((Range)TakeRange);
            if (Reserve) result = result.Reverse();

            return await Task.FromResult(new SuccessReturnModel<IEnumerable<TEntity>>("Başarıyla Getirildi", result));
        }
    }
    abstract public class AbstractRepositoryCore<TEntityCore, TContext> : IRepositoryCore<TEntityCore>
        where TEntityCore : class, IEntityCore, new()
        where TContext : DbContext, new()
    {
        internal readonly TContext context;
        public AbstractRepositoryCore(TContext context)
        {
            this.context = context;
        }
        public IReturnModel<TEntityCore> Add(TEntityCore entity)
        {
            context.Set<TEntityCore>().Add(entity);
            return Save(entity);
        }

        public IReturnModel<IEnumerable<TEntityCore>> Add(IEnumerable<TEntityCore> entity)
        {
            context.Set<TEntityCore>().AddRange(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<TEntityCore>> AddAsync(TEntityCore entity)
        {
            await context.Set<TEntityCore>().AddAsync(entity);
            return await SaveAsync(entity);
        }

        public async Task<IReturnModel<IEnumerable<TEntityCore>>> AddAsync(IEnumerable<TEntityCore> entity)
        {
            await context.Set<TEntityCore>().AddRangeAsync(entity);
            return await SaveAsync(entity);
        }

        public IReturnModel<TNull> CheckIsNull<TNull>(TNull? result) 
            => (result == null) ? new SuccessReturnModel<TNull>("Data is null") : new SuccessReturnModel<TNull>("Data is not null", result);

        public IReturnModel<int> Count(Expression<Func<TEntityCore, bool>>? filter = null)
        {
            try
            {
                return new SuccessReturnModel<int>(filter == null ? context.Set<TEntityCore>().AsNoTracking().Count() : context.Set<TEntityCore>().AsNoTracking().Count(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<int>(e);
            }
        }

        public async Task<IReturnModel<int>> CountAsync(Expression<Func<TEntityCore, bool>>? filter = null)
        {
            try
            {
                return new SuccessReturnModel<int>(filter == null ? await context.Set<TEntityCore>().AsNoTracking().CountAsync() : await context.Set<TEntityCore>().AsNoTracking().CountAsync(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<int>(e);
            }
        }

        public IReturnModel<TEntityCore> Delete(TEntityCore entity)
        {
            context.Set<TEntityCore>().Remove(entity);
            return Save(entity);
        }

        public IReturnModel<IEnumerable<TEntityCore>> Delete(IEnumerable<TEntityCore> entity)
        {
            context.Set<TEntityCore>().RemoveRange(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<TEntityCore>> DeleteAsync(TEntityCore entity)
        {
            context.Set<TEntityCore>().Remove(entity);
            return await SaveAsync(entity);
        }

        public async Task<IReturnModel<IEnumerable<TEntityCore>>> DeleteAsync(IEnumerable<TEntityCore> entity)
        {
            context.Set<TEntityCore>().RemoveRange(entity);
            return await SaveAsync(entity);
        }

        public IReturnModel<TEntityCore> Get(Expression<Func<TEntityCore, bool>> filter)
        {
            var result = context.Set<TEntityCore>().AsNoTracking().FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<TEntityCore>> GetAsync(Expression<Func<TEntityCore, bool>> filter)
        {
            var result = await context.Set<TEntityCore>().AsNoTracking().FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }

        public IReturnModel<bool> IsExist(Expression<Func<TEntityCore, bool>> filter)
        {
            try
            {
                return new SuccessReturnModel<bool>(context.Set<TEntityCore>().AsNoTracking().Any(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<bool>(e);
            }
        }

        public async Task<IReturnModel<bool>> IsExistAsync(Expression<Func<TEntityCore, bool>> filter)
        {
            try
            {
                return new SuccessReturnModel<bool>(await context.Set<TEntityCore>().AsNoTracking().AnyAsync(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<bool>(e);
            }
        }

        public IReturnModel<TEntityCore> Save(TEntityCore entity)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return new SuccessReturnModel<TEntityCore>(entity);
                }
                return new ErrorReturnModel<TEntityCore>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<TEntityCore>(entity, e);
            }
        }

        public IReturnModel<IEnumerable<TEntityCore>> Save(IEnumerable<TEntityCore> entity)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return new SuccessReturnModel<IEnumerable<TEntityCore>>(entity);
                }
                return new ErrorReturnModel<IEnumerable<TEntityCore>>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<IEnumerable<TEntityCore>>(entity, e);
            }
        }

        public async Task<IReturnModel<TEntityCore>> SaveAsync(TEntityCore entity)
        {
            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new SuccessReturnModel<TEntityCore>(entity);
                }
                return new ErrorReturnModel<TEntityCore>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<TEntityCore>(entity, e);
            }
        }

        public async Task<IReturnModel<IEnumerable<TEntityCore>>> SaveAsync(IEnumerable<TEntityCore> entity)
        {
            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new SuccessReturnModel<IEnumerable<TEntityCore>>(entity);
                }
                return new ErrorReturnModel<IEnumerable<TEntityCore>>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<IEnumerable<TEntityCore>>(entity, e);
            }
        }

        public IReturnModel<TEntityCore> Update(TEntityCore entity)
        {
            context.Set<TEntityCore>().Update(entity);
            return Save(entity);
        }

        public IReturnModel<IEnumerable<TEntityCore>> Update(IEnumerable<TEntityCore> entity)
        {
            context.Set<TEntityCore>().UpdateRange(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<TEntityCore>> UpdateAsync(TEntityCore entity)
        {
            context.Set<TEntityCore>().Update(entity);
            return await SaveAsync(entity);
        }

        public async Task<IReturnModel<IEnumerable<TEntityCore>>> UpdateAsync(IEnumerable<TEntityCore> entity)
        {
            context.Set<TEntityCore>().UpdateRange(entity);
            return await SaveAsync(entity);
        }

        public IReturnModel<IEnumerable<TEntityCore>> _GetAll<TOrder>(Expression<Func<TEntityCore, bool>>? filter = null, Expression<Func<TEntityCore, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null)
        {
            // burada bir sorun var take ile çalışmada sorun var birde range de eklemede sorun var
            IQueryable<TEntityCore> result = context.Set<TEntityCore>().AsNoTracking();
            
            if (filter != null) result = result.Where(filter);
            if (order != null) result = result.OrderBy(order);
            if (Reserve) result = result.Reverse();
            if (TakeRange != null)
            {
                return new SuccessReturnModel<IEnumerable<TEntityCore>>("Başarıyla Getirildi", result.ToList().Take(TakeRange.Value));
            }
           
            return new SuccessReturnModel<IEnumerable<TEntityCore>>("Başarıyla Getirildi", result.ToList());
        }

        public async Task<IReturnModel<IEnumerable<TEntityCore>>> _GetAllAsync<TOrder>(Expression<Func<TEntityCore, bool>>? filter = null, Expression<Func<TEntityCore, TOrder>>? order = null, bool Reserve = false, Range? TakeRange = null)
        {
            //zoraki async
            IQueryable<TEntityCore> result = context.Set<TEntityCore>().AsNoTracking();

            if (filter != null) result = result.Where(filter);
            if (order != null) result = result.OrderBy(order);
            if (Reserve) result = result.Reverse();
            if (TakeRange != null)
            {
                return new SuccessReturnModel<IEnumerable<TEntityCore>>("Başarıyla Getirildi", result.ToList().Take(TakeRange.Value));
            }

            return new SuccessReturnModel<IEnumerable<TEntityCore>>("Başarıyla Getirildi", await result.ToListAsync());
        }
    }
}
