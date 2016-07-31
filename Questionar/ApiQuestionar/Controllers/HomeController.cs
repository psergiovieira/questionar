using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiQuestionar.Auxiliary;
using Data;
using Data.Security;
using Domain.Manager;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;

namespace ApiQuestionar.Controllers
{
    public class HomeController : ApiController
    {
        private readonly HomeManager _manager;
        private readonly CourseManager _courseManager;
        private readonly SubscribeManager _subscribeManager;
        private readonly AnswerManager _answerManager;
        private readonly QuestionManager _questionManager;
        private readonly UserManager _userManager;

        public HomeController()
        {
            _manager = new HomeManager();
            var unitOfWork = new NhibernateUnitOfWork();
            _courseManager = new CourseManager(new NHibernateRepository<Course>(unitOfWork), unitOfWork);
            _subscribeManager = new SubscribeManager(new NHibernateRepository<Subscription>(unitOfWork), unitOfWork);
            _answerManager = new AnswerManager(new NHibernateRepository<Answer>(unitOfWork), unitOfWork);
            _questionManager = new QuestionManager(new NHibernateRepository<Question>(unitOfWork), unitOfWork);
            _userManager = new UserManager(new NHibernateRepository<User>(unitOfWork), unitOfWork);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            var user = this.GetUser();
            var result = _manager.Get(_courseManager, user, _subscribeManager, _answerManager, _questionManager, _userManager);

            return Ok(result);
        }
    }
}