using ApiQuestionar.Auxiliary;
using Data;
using Domain.Manager;
using Domain.Models;
using Infraestructure.Repository;
using System.Linq;
using System.Web.Http;

namespace ApiQuestionar.Controllers
{
    public class QuestionController : BaseController<Question>
    {
        private readonly QuestionManager _manager;
        private readonly AlternativeManager _alternativeManager;
        private readonly SendQuestionManager _sendQuestionManager;
        private readonly SubscribeManager _subscribeManager;

        public QuestionController()
        {
            _manager = new QuestionManager(Repository, UnitOfWork);
            _alternativeManager = new AlternativeManager(new NHibernateRepository<Alternative>(UnitOfWork), UnitOfWork);
            _sendQuestionManager = new SendQuestionManager(new NHibernateRepository<UserQuestion>(UnitOfWork), UnitOfWork);
            _subscribeManager = new SubscribeManager(new NHibernateRepository<Subscription>(UnitOfWork), UnitOfWork);
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

            _manager.Create(_alternativeManager, _sendQuestionManager, _subscribeManager, question, args.Course, args.Alternatives);
            return Ok("Questão cadastrada com sucesso!");
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var user = this.GetUser();
            var result = _manager.ListByTeacher(_alternativeManager, user).Select(c => new MQuestion()
            {
                Description = c.Description,
                Course = new Course() { Description = c.Course.Description, Name = c.Course.Name },
                Alternatives = c.Alternatives.OrderBy(a=>a.Order).Select(a => new Alternative() { Description = a.Description, Id = a.Id, Order = a.Order, IsCorrect = a.IsCorrect}).ToList()
            }).ToList();

            return Ok(result);
        }
    }
}