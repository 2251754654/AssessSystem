using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using Repositorys.DataAccess;
using Repositorys.DataAccess.Context;

namespace Repositorys.Repository.Generic
{
    /// <summary>
    /// 通用仓储类，实现了通用的增删改查
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DBContext Context { get; set; }
        private DbSet<TEntity> dbSet;

        public void InitDbContext(DBContext dbContext)
        {
            this.Context = dbContext;
            this.dbSet = Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,int? page = null,int? number=null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query =  orderBy(query);
            }
            //分页
            if (page != null && number != null)
            {
                var pageResult = query.AsEnumerable();
                int pageNumber = (int)page - 1;
                int everyPageNumber = (int)number;

                return pageResult.Skip(pageNumber * everyPageNumber).Take(everyPageNumber).AsQueryable() ;
            }
            else
            {
                return query;
            }
        }

        public virtual TEntity GetByID(Guid guid)
        {
            return dbSet.Find(guid);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Insert(List<TEntity> entity)
        {
            dbSet.AddRange(entity);
        }

        public virtual void Delete(Guid guid)
        {
            TEntity entityToDelete = dbSet.Find(guid);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Delete(List<TEntity> entityToDelete)
        {
            dbSet.RemoveRange(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            var entity = Context.Entry(entityToUpdate);
            if (entity.State == EntityState.Detached)
            {
                dbSet.Attach(entityToUpdate);
            }
            entity.State = EntityState.Modified;
        }

        public virtual void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "<public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class> error !");
            }
            finally
            {
                Context.Dispose();
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}