using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KariyerNetBackendTestCase.Core.DataAccess.Abstract;
using KariyerNetBackendTestCase.Core.Entity;
using KariyerNetBackendTestCase.Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KariyerNetBackendTestCase.Core.DataAccess.Base
{
    public abstract class EntityFrameworkRepositoryBase<TEntity, TPrimaryKey> :
        IQueryableRepository<TEntity, TPrimaryKey>,
        IUpdateableRepository<TEntity, TPrimaryKey>,
        IDeleteableRepository<TEntity, TPrimaryKey>,
        IInsertableRepository<TEntity, TPrimaryKey>,
        IPageableRepository<TEntity, TPrimaryKey>,
        ISwitchableRepository<TEntity, TPrimaryKey>,
        ITrashableRepository<TEntity, TPrimaryKey>,
        ICustomQueryRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>, new()
        where TPrimaryKey : struct
    {
    
 
        private bool _isActiveGlobalQuery = true;


        protected EntityFrameworkRepositoryBase(DbContext context )
        {
  
            Context = context; 
            DbSet = Context.Set<TEntity>(); 
        }

        /// <summary>
        /// Database arama sonuçlarının sorgusunun alınacağı method
        /// </summary>
        /// <returns></returns>
        public DbSet<TEntity> DbSet { get; }
        /// <summary>
        /// Database arama sonuçlarının sorgusunun alınacağı method
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> Query
        {
            get
            {
                var query = DbSet.AsQueryable();

                if (!_isActiveGlobalQuery) return query;
 

                return query;
            }
        }
        public DbContext Context { get; }

 
        public virtual int Save() => Context.SaveChanges();
        public virtual Task<int> SaveAsync() => Context.SaveChangesAsync();
        public virtual IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Query;

            if (filter != null) query = query.Where(filter);
            if (orderBy != null) query = orderBy(query);
            if (topRecords.HasValue && topRecords > 0) query = query.Take(topRecords.Value);

            if (includes != null && includes.Any())
            {
                foreach (var include in includes) query = query.Include(include);
            }

            return query.AsQueryable();
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = GetQuery(filter, orderBy, topRecords, includes);

            return query.ToList();
        }

        public virtual List<TResult> GetList<TResult>(Expression<Func<TEntity, TResult>> @select, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null, params Expression<Func<TEntity, object>>[] includes) where TResult : class, new()
        {
            IQueryable<TEntity> query = GetQuery(filter, orderBy, topRecords, includes);

            return query.Select(select).ToList();

        }

        public virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = GetQuery(filter, orderBy, topRecords, includes);

            return query.ToListAsync();
        }

        public virtual Task<List<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, TResult>> @select, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? topRecords = null,
            params Expression<Func<TEntity, object>>[] includes) where TResult : class, new()
        {
            IQueryable<TEntity> query = GetQuery(filter, orderBy, topRecords, includes);

            return query.Select(select).ToListAsync();
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter) => Query.FirstOrDefault(filter);

        public virtual TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> @select, Expression<Func<TEntity, bool>> filter) where TResult : class, new()
        {
            return GetQuery(filter).Select(select).FirstOrDefault();
        }

        public virtual TEntity GetByIdFirstOrDefault(TPrimaryKey id) => Queryable.FirstOrDefault(Query, x => x.Id.Equals(id));

        public virtual TResult GetByIdFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> @select, TPrimaryKey id) where TResult : class, new() => Queryable.Where(Query, x => x.Id.Equals(id)).Select(@select).FirstOrDefault();

        public virtual Task<TResult> GetByIdFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> @select, TPrimaryKey id) where TResult : class, new() => Queryable.Where(Query, x => x.Id.Equals(id)).Select(@select).FirstOrDefaultAsync();

        public virtual Task<TEntity> GetByIdFirstOrDefaultAsync(TPrimaryKey id) => Query.FirstOrDefaultAsync(x => x.Id.Equals(id));

        public virtual List<TEntity> GetById(params TPrimaryKey[] id) => GetQuery(x => id.Contains(x.Id)).ToList();

        public virtual List<TResult> GetById<TResult>(Expression<Func<TEntity, TResult>> @select, params TPrimaryKey[] id) where TResult : class, new()
        {
            return GetQuery(x => id.Contains(x.Id)).Select(select).ToList();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter = null) => GetQuery(filter).Any();

        public virtual int RecordCount(Expression<Func<TEntity, bool>> filter = null) => GetQuery(filter).Count();

        public virtual Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter) => GetQuery(filter).FirstOrDefaultAsync();

        public virtual Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> @select, Expression<Func<TEntity, bool>> filter) where TResult : class, new()
        {
            return GetQuery(filter).Select(select).FirstOrDefaultAsync();
        }

        public virtual Task<List<TEntity>> GetByIdAsync(params TPrimaryKey[] id) => GetQuery(x => id.Contains(x.Id)).ToListAsync();

        public virtual Task<List<TResult>> GetByIdAsync<TResult>(Expression<Func<TEntity, TResult>> @select, params TPrimaryKey[] id) where TResult : class, new()
        {
            return GetQuery(x => id.Contains(x.Id)).Select(select).ToListAsync();
        }

        public virtual Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter = null) => GetQuery(filter).AnyAsync();

        public virtual Task<int> RecordCountAsync(Expression<Func<TEntity, bool>> filter = null) => GetQuery(filter).CountAsync();

        public virtual TEntity Update(TEntity entity, params Expression<Func<TEntity, object>>[] excludedColumns)
        {
            if (entity == null) return null;

 

            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;

            if (excludedColumns != null && excludedColumns.Any())
                foreach (var item in excludedColumns)
                    entry.Property(item).IsModified = false;


            return entity;
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] excludedColumns)
        {
            Update(entity, excludedColumns);

            return Task.FromResult(entity);
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> filter)
        {


            var entityList = GetList(filter);

            return Delete(entityList);
        }

        public virtual int Delete(TEntity entity)
        {
            if (entity == null) return 0;
 

            DbSet.Remove(entity);

            return 1;
        }

        public virtual int Delete(TPrimaryKey id)
        {
            var entityToDelete = GetById(id);
            return Delete(entityToDelete);
        }

        public virtual int Delete(params TPrimaryKey[] id)
        {
            var entityToDelete = GetById(id);
            return Delete(entityToDelete);
        }

        public virtual int Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any()) return 0;
 



            DbSet.RemoveRange(entities);

            return entities.Count();
        }

        public virtual Task<int> DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = GetList(filter);

            Delete(entities);

            return Task.FromResult(entities.Count);
        }

        public virtual Task<int> DeleteAsync(TEntity entity)
        {
            if (entity == null) return Task.FromResult(0);
     


            DbSet.Remove(entity);

            return Task.FromResult(1);
        }

        public virtual Task<int> DeleteAsync(TPrimaryKey id)
        {
            var entityToDelete = GetById(id);
            return DeleteAsync(entityToDelete);
        }

        public virtual Task<int> DeleteAsync(params TPrimaryKey[] id)
        {
            var entityToDelete = GetById(id);
            if (entityToDelete == null || !entityToDelete.Any()) return Task.FromResult(0);

            return DeleteAsync(entityToDelete);
        }

        public virtual Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any()) return Task.FromResult(0);
       



            DbSet.RemoveRange(entities);

            return Task.FromResult(entities.Count());
        }

        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
 
            DbSet.Add(entity);
            Context.SaveChanges();
            return entity.Id;
        }

        public virtual TEntity Add(TEntity entity)
        {
 
            DbSet.Add(entity);
             

            return entity;
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
 

            DbSet.AddRange(entities);

            

        }

        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
 

            DbSet.AddAsync(entity);

            return Task.FromResult(entity);
        }

        public virtual Task AddAsync(IEnumerable<TEntity> entities)
        {
 

            DbSet.AddRangeAsync(entities);

            return Task.CompletedTask;
        }

        public Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {

 
            DbSet.Add(entity);
            Context.SaveChangesAsync();
            return Task.FromResult<TPrimaryKey>(entity.Id);

        }

        public virtual PagedResult<TEntity> GetPagedList(int page = 1, int? pageSize = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            pageSize ??= 50;

            var result = new PagedResult<TEntity>(page, pageSize.Value, RecordCount(filter));
            result.List = GetPagedListQuery(page, pageSize.Value, filter, orderBy, includes).ToList();


            return result;
        }

        public virtual Task<PagedResult<TEntity>> GetPagedListAsync(int page = 1, int? pageSize = null, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            pageSize ??= 50;


            var result = new PagedResult<TEntity>(page, pageSize.Value, RecordCountAsync(filter).Result);
            result.List = GetPagedListQuery(page, pageSize.Value, filter, orderBy, includes).ToListAsync().Result;

            return Task.FromResult(result);
        }

        public virtual PagedResult<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> @select, int page = 1, int? pageSize = null, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where TResult : class, new()
        {
            pageSize ??= 50;

            var result = new PagedResult<TResult>(page, pageSize.Value, RecordCount(filter));
            result.List = GetPagedListQuery(page, pageSize.Value, filter, orderBy).Select(@select).ToList();

            return result;
        }

        public virtual Task<PagedResult<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> @select, int page = 1, int? pageSize = null, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            pageSize ??= 50;

            var result = new PagedResult<TResult>(page, pageSize.Value, RecordCountAsync(filter).Result);
            result.List = GetPagedListQuery(page, pageSize.Value, filter, orderBy).Select(@select).ToListAsync().Result;

            return Task.FromResult(result);
        }

        public virtual TEntity ToggleStatus(TPrimaryKey id)
        {
            TEntity entityToToggleStatus = GetByIdFirstOrDefault(id);
            if (entityToToggleStatus == null) return null;


 
            Update(entityToToggleStatus);

            return entityToToggleStatus;

        }

        public virtual IEnumerable<TEntity> ToggleStatus(params TPrimaryKey[] id)
        {
            List<TEntity> entities = new List<TEntity>();

            foreach (var record in id)
            {
                TEntity entity = GetByIdFirstOrDefault(record);
                if (entity == null) return null;

                entities.Add(ToggleStatus(entity));
            }

            return entities;
        }

        public virtual TEntity ToggleStatus(TEntity entity)
        {
            if (entity == null) return null;

 
            Update(entity);

            return entity;

        }

        public virtual Task<TEntity> ToggleStatusAsync(TPrimaryKey id)
        {
            TEntity entityToToggleStatus = GetByIdFirstOrDefaultAsync(id).Result;
            if (entityToToggleStatus == null) return Task.FromResult(entityToToggleStatus);

 
            UpdateAsync(entityToToggleStatus);

            return Task.FromResult(entityToToggleStatus);
        }

        public virtual Task<List<TEntity>> ToggleStatusAsync(params TPrimaryKey[] id)
        {
            List<TEntity> entities = new List<TEntity>();

            Parallel.ForEach(id, x =>
            {
                TEntity entity = GetByIdFirstOrDefaultAsync(x).Result;
                if (entity != null)
                {
                    entities.Add(ToggleStatusAsync(entity).Result);
                }
            });

            return Task.FromResult(entities);
        }

        public virtual Task<TEntity> ToggleStatusAsync(TEntity entity)
        {
            if (entity == null) return Task.FromResult(entity);

 
            UpdateAsync(entity);

            return Task.FromResult(entity);

        }

        public virtual int MoveToTrash(TPrimaryKey id)
        {
            TEntity entity = GetByIdFirstOrDefault(id);
            if (entity == null) return 0;

            return MoveToTrash(entity);
        }

        public virtual int MoveToTrash(params TPrimaryKey[] id)
        {
            var entities = GetById(id);

            if (entities == null || !entities.Any()) return 0;

            return MoveToTrash(entities);
        }

        public virtual int MoveToTrash(TEntity entity)
        {
            if (entity == null) return 0;

             Update(entity);

            return 1;
        }

        public virtual int MoveToTrash(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any()) return 0;

            foreach (var entity in entities)
            {
                MoveToTrash(entity);
            }

            return entities.Count();
        }

        public virtual Task<int> MoveToTrashAsync(TPrimaryKey id)
        {
            TEntity entity = GetByIdFirstOrDefaultAsync(id).Result;
            if (entity == null) return Task.FromResult(0);

            return MoveToTrashAsync(entity);
        }

        public virtual Task<int> MoveToTrashAsync(params TPrimaryKey[] id)
        {
            var entities = GetByIdAsync(id).Result;

            if (entities == null || !entities.Any()) Task.FromResult(0);

            MoveToTrashAsync(entities);

            return Task.FromResult(entities.Count);
        }

        public virtual Task<int> MoveToTrashAsync(TEntity entity)
        {
            if (entity == null) Task.FromResult(0);

             UpdateAsync(entity);

            return Task.FromResult(1);

        }

        public virtual Task<int> MoveToTrashAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any()) Task.FromResult(0);

            Parallel.ForEach(entities, entity =>
            {
                MoveToTrashAsync(entity);

            });

            return Task.FromResult(entities.Count());

        }



        public virtual int RollBackFromTrash(TPrimaryKey id)
        {
            TEntity entity = GetByIdFirstOrDefault(id);
            if (entity == null) return 0;

            return RollBackFromTrash(entity);
        }

        public virtual int RollBackFromTrash(params TPrimaryKey[] id)
        {
            var entities = GetById(id);

            if (entities == null || !entities.Any()) return 0;

            return RollBackFromTrash(entities);
        }

        public virtual int RollBackFromTrash(TEntity entity)
        {
            if (entity == null) return 0;

             Update(entity);

            return 1;
        }

        public virtual int RollBackFromTrash(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any()) return 0;

            foreach (var entity in entities)
            {
                RollBackFromTrash(entity);
            }

            return entities.Count();
        }

        public virtual Task<int> RollBackFromTrashAsync(TPrimaryKey id)
        {
            TEntity entity = GetByIdFirstOrDefaultAsync(id).Result;
            if (entity == null) return Task.FromResult(0);

            return RollBackFromTrashAsync(entity);
        }

        public virtual Task<int> RollBackFromTrashAsync(params TPrimaryKey[] id)
        {
            var entities = GetByIdAsync(id).Result;

            if (entities == null || !entities.Any()) Task.FromResult(0);

            RollBackFromTrashAsync(entities);

            return Task.FromResult(entities.Count);
        }

        public virtual Task<int> RollBackFromTrashAsync(TEntity entity)
        {
            if (entity == null) Task.FromResult(0);

 
            UpdateAsync(entity);

            return Task.FromResult(1);
        }

        public virtual Task<int> RollBackFromTrashAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any()) Task.FromResult(0);

            Parallel.ForEach(entities, entity =>
            {
                RollBackFromTrashAsync(entity);

            });

            return Task.FromResult(entities.Count());
        }
        public virtual IEnumerable<TEntity> ExecuteQuery(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            return DbSet.FromSqlRaw(customQuery.ToString()).ToList();
        }

        public virtual object ExecuteSpecialQuery(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            return DbSet.FromSqlRaw(customQuery.ToString()).ToList();
        }

        public virtual TEntity ExecuteQueryFirstRow(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            return DbSet.FromSqlRaw(customQuery.ToString()).FirstOrDefault();
        }

        public virtual int ExecuteQueryGetValue(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            return Context.Database.ExecuteSqlRaw(customQuery.ToString());
        }

        public virtual void ExecuteQueryVoid(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            Context.Database.ExecuteSqlRaw(customQuery.ToString());
        }

        public virtual Task<List<TEntity>> ExecuteQueryAsync(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            return DbSet.FromSqlRaw(customQuery.ToString()).ToListAsync();
        }


        public virtual Task<TEntity> ExecuteQueryFirstRowAsync(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            return DbSet.FromSqlRaw(customQuery.ToString()).FirstOrDefaultAsync();
        }

        public virtual Task<int> ExecuteQueryGetValueAsync(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            return Context.Database.ExecuteSqlRawAsync(customQuery.ToString());
        }

        public virtual Task ExecuteQueryVoidAsync(object customQuery, int commandTimeOut = 30)
        {
            Context.Database.SetCommandTimeout(commandTimeOut);
            Context.Database.ExecuteSqlRawAsync(customQuery.ToString());

            return Task.CompletedTask;
        }
        public virtual void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        #region Private Methods
        private IQueryable<TEntity> GetPagedListQuery(int page = 1, int pageSize = 50, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var skip = (page - 1) * pageSize;

            var query = GetQuery(filter, orderBy, null, includes);

            query.Skip(skip).Take(pageSize);

            return query;
        }

 

 


 

        #endregion

    }
}
