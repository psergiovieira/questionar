using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Infraestructure.Repository;
using Infraestructure.Types;
using Infraestructure;
using Infraestructure.UnitOfWork;

namespace ApiQuestionar.Controllers
{
    public class BaseController<TEntity> : ApiController where TEntity : IIdentity
    {
        private IRepository<TEntity> _repository;
        private IUnitOfWork _unitOfWork;

        public BaseController() 
        {
            _unitOfWork = new NhibernateUnitOfWork();
            _repository = new NHibernateRepository<TEntity>(_unitOfWork);
        }

        public IRepository<TEntity> Repository
        {
          get { return _repository; }
          set { _repository = value; }
        }
        
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
            set { _unitOfWork = value; }
        }
    }
}