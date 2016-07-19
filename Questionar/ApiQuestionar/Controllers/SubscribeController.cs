using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiQuestionar.Auxiliary;
using Data;
using Domain.Manager;
using Infraestructure.Repository;

namespace ApiQuestionar.Controllers
{
    public class SubscribeController : BaseController<Subscription>
    {
        private SubscribeManager _manager;
        private SendQuestionManager _sendQuestionManager;
        private QuestionManager _questionManager;

        public SubscribeController()
        {
            _manager = new SubscribeManager(Repository, UnitOfWork);
            _sendQuestionManager = new SendQuestionManager(new NHibernateRepository<UserQuestion>(UnitOfWork), UnitOfWork );
            _questionManager = new QuestionManager(new NHibernateRepository<Question>(UnitOfWork), UnitOfWork);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(Course course)
        {
            _manager.Subscribe(this.GetUser(), course, _sendQuestionManager, _questionManager);
            return Ok("Inscrito com sucesso!");
        }
    }
}