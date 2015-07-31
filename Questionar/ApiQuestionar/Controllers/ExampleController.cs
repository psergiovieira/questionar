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

        public IHttpActionResult Put()
        {
            //TODO: fazer conexao com o bd
            //TODO: adicionar transaction(unit of work with filter attribute)
            //TODO: usar injeção de dependencias para instanciar IUnitOfWork e IRepoitory            
            _manager = new ExampleManager(Repository);

            return Ok();
        }
    }
}