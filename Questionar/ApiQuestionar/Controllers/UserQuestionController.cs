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
    public class UserQuestionController : BaseController<UserQuestion>
    {
        public SendQuestionManager _manager;
        public AlternativeManager _alternativeManager;

        public UserQuestionController()
        {
            _manager = new SendQuestionManager(Repository, UnitOfWork);
            _alternativeManager = new AlternativeManager(new NHibernateRepository<Alternative>(UnitOfWork), UnitOfWork );
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var user = this.GetUser();
            var result = _manager.DailyQuestion(this.GetUser(), _alternativeManager);

            return Ok(result);
        }
    }
}