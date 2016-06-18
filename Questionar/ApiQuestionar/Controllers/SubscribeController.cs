using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiQuestionar.Auxiliary;
using Data;
using Domain.Manager;

namespace ApiQuestionar.Controllers
{
    public class SubscribeController : BaseController<Subscription>
    {
        private SubscribeManager _manager;

        public SubscribeController()
        {
            _manager = new SubscribeManager(Repository, UnitOfWork);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(Course course)
        {
            _manager.Subscribe(this.GetUser(),course);
            return Ok("Inscrito com sucesso!");
        }
    }
}