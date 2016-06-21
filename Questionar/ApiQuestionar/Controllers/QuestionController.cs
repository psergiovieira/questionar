using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiQuestionar.Models;
using Data;
using Domain.Manager;
using Infraestructure.Repository;

namespace ApiQuestionar.Controllers
{
    public class QuestionController : BaseController<Question>
    {
        private QuestionManager _manager;
        private AlternativeManager _alternativeManager;

        public QuestionController()
        {
            _manager = new QuestionManager(Repository, UnitOfWork);
            _alternativeManager = new AlternativeManager(new NHibernateRepository<Alternative>(UnitOfWork), UnitOfWork);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(MQuestion args)
        {
            var question = new Question
            {
                Course = args.Course,
                Description = args.Description
            };

            _manager.Create(_alternativeManager, question, args.Course, args.Alternatives);
            return Ok("Questão cadastrada com sucesso!");
        }
    }
}