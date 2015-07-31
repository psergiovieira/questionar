using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Types;
using Infraestructure.UnitOfWork;


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
    }
}
