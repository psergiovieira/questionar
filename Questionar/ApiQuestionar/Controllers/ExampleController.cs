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
    public class ExampleController : BaseController<Example>
    {
        private ExampleManager _manager;
        public ExampleController()
        {
            _manager = new ExampleManager(Repository, UnitOfWork); 
        }

        public IHttpActionResult Put()
        {
            //TODO: fazer conexao com o bd            
            //TODO: usar injeção de dependencias para instanciar IUnitOfWork e IRepoitory            
            return Ok();
        }
    }
}