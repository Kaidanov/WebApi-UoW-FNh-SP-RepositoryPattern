using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Domain.Entities;

namespace UnitOfWork.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);

        IList<TEntity> SqlQueryList<TEntity>(string sql);
        TEntity SqlQuery<TEntity>(string sql);
    }
}
