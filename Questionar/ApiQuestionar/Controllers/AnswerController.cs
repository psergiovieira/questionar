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
    public class AnswerController : BaseController<Answer>
    {
        private AnswerManager _manager;

        public AnswerController()
        {
            _manager = new AnswerManager(Repository, UnitOfWork);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(Alternative alternative)
        {
            var alternativeManager = new AlternativeManager(new NHibernateRepository<Alternative>(UnitOfWork), UnitOfWork);
            var sendQuestionManager = new SendQuestionManager(new NHibernateRepository<UserQuestion>(UnitOfWork), UnitOfWork);
            var result = _manager.Reply(alternative.Id, this.GetUser(), alternativeManager, sendQuestionManager);
            var response = result ? "Você acertou. Parabéns!" : "Resposta errada! Não desanime, continue estudando.";

            return Ok(response);
        }
    }
}