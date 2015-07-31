using Infraestructure.Types;
using Infraestructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Business
{
    public class Business<TEntity> where TEntity : IIdentity
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<TEntity> _repository;
        public IRepository<TEntity> Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        public Business(IRepository<TEntity> repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        protected void Transaction(Action metodo)
        {
            _unitOfWork.BeginTransaction();

            try
            {
                metodo();
                _unitOfWork.Commit();
            }
            catch (WebException wEx)
            {
                _unitOfWork.Rollback();
                throw wEx;
            }
            catch (ApplicationException adoex)
            {
                _unitOfWork.Rollback();
                throw adoex;

            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }
    }
}
