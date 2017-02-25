using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Data.Helpers;
using UnitOfWork.Domain.Entities;
using UnitOfWork.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;
using UnitOfWork.Data.MappingOverrides;
using NHibernate.Tool.hbm2ddl;
using UnitOfWork.Domain.Helpers;
using MyUNitOfWork = UnitOfWork.Data.Helpers.UnitOfWork;
using NHibernate.Transform;


namespace UnitOfWork.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private MyUNitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork){
            _unitOfWork = (MyUNitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Create(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }

        public IList<TEntity> SqlQueryList<TEntity>(string sql)
        {
     

            IList<TEntity> result = Session.CreateSQLQuery(sql)
                                .SetResultTransformer(Transformers.AliasToBean<TEntity>())
                                .List<TEntity>();

            return result;
        }

        public TEntity SqlQuery<TEntity>(string sql)
        {
            return (TEntity) Session.CreateSQLQuery(sql).SetResultTransformer(Transformers.AliasToBean<TEntity>()).UniqueResult();
        }
    }
}
