using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Repositorys.DataAccess;
using Repositorys.DataAccess.Context;

namespace Repositorys.Repository.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void InitDbContext(DBContext dbContext);
        void Delete(Guid guid);
        void Delete(TEntity entityToDelete);
        void Delete(List<TEntity> entityToDelete);
        void Dispose();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? page = null, int? number = null);
        TEntity GetByID(Guid guid);
        void Insert(TEntity entity);
        void Insert(List<TEntity> entity);
        void Save();
        void Update(TEntity entityToUpdate);
    }
}