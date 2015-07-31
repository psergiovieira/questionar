using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Domain.Manager;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;
namespace ApiQuestionar.Controllers
{
    public class ExemploController : ApiController
    {
        private ExemploManager _manager;

        public IHttpActionResult Put()
        {
            var repository = new NHibernateRepository<Exemplo>(new NhibernateUnitOfWork());
            _manager = new ExemploManager(repository);

            return Ok();
        }
    }
}