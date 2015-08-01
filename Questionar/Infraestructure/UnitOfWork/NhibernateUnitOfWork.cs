using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.UnitOfWork
{
    public class NhibernateUnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static NhibernateUnitOfWork()
        {
            var configuration = new Configuration();
            configuration.Configure();
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public NhibernateUnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
                _transaction.Rollback();
        }
    }
}
