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

        [HttpGet]
        public IHttpActionResult Get()
        {   
            return Ok("teste");
        }
    }
}