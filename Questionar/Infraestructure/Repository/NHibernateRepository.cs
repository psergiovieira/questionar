using Infraestructure.Types;
using Infraestructure.UnitOfWork;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Infraestructure.Repository
{
    public class NHibernateRepository<T> : IRepository<T> where T : IIdentity
    {
        private NhibernateUnitOfWork _unitOfWork;
        public NHibernateRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (NhibernateUnitOfWork)unitOfWork;
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

        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            return Session.Query<T>();
        }

        public T Get<T>(object id)
        {
            return Session.Get<T>(id);
        }
    }
}
