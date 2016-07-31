using System;
using System.Collections.Generic;
using Data;
using Data.Security;
using Domain.Exceptions;
using Domain.Manager;
using Infraestructure;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestDomain
{
    [TestClass]
    public class UnitTestQuestion
    {
        private Mock<IRepository<Question>> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IRepository<Alternative>> _mockAlternative;
        private Mock<IRepository<UserQuestion>> _mockUserQuestion;
        private Mock<IRepository<Subscription>> _mockSubscribe;

        private QuestionManager _manager;
        private AlternativeManager _alternativeManager;
        private SendQuestionManager _sendQuestionManager;
        private SubscribeManager _subscribeManager;
        private Course _course;
        private User _teacher;
        private Question _question;
        private List<Alternative> _alternatives;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IRepository<Question>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _manager = new QuestionManager(_mockRepository.Object, _mockUnitOfWork.Object);


            var unitOfWorkAlternative = new Mock<IUnitOfWork>();
            _mockAlternative = new Mock<IRepository<Alternative>>();
            _alternativeManager = new AlternativeManager(_mockAlternative.Object, unitOfWorkAlternative.Object);

            var unitOfWorkSendQuestion = new Mock<IUnitOfWork>();
            _mockUserQuestion = new Mock<IRepository<UserQuestion>>();
            _sendQuestionManager = new SendQuestionManager(_mockUserQuestion.Object, unitOfWorkSendQuestion.Object);
            
            _mockSubscribe = new Mock<IRepository<Subscription>>();
            var unitOfWorkSubscribe = new Mock<IUnitOfWork>();
            _subscribeManager = new SubscribeManager(_mockSubscribe.Object, _mockUnitOfWork.Object);

            _teacher = new User() { Id = 1, IsTeacher = true, Name = "Professor" };
            _course = new Course()
            {
                Description = "Testes",
                Name = "Matematica",
                Id = 1,
                Created = new DateTime(2016, 01, 01),
                Teacher = _teacher
            };

            _question = new Question
            {
                Id = 1,
                Course = _course,
                Description = "Quanto é 1 + 1"
            };

            _alternatives = new List<Alternative>();
            for (int i = 0; i < 10; i++)
            {
                _alternatives.Add(new Alternative()
                {
                    Question = _question,
                    Description = " teste numero " + 1,
                    IsCorrect = false,
                    Order = i
                });
            }

            _alternatives.Add(new Alternative()
            {
                Question = _question,
                Description = " teste numero " + _alternatives.Count,
                IsCorrect = true,
                Order = _alternatives.Count

            });
        }
        [TestMethod]
        public void TestMapping()
        {
            var entity = new NHibernateRepository<Question>(new NhibernateUnitOfWork()).GetAll();
        }

        [TestMethod]
        public void CanGetQuestion()
        {
            _mockRepository.Setup(x => x.GetById(1)).Returns(_question);
            var question = _manager.Repository.GetById(1);
            Assert.AreEqual(_question, question);
        }

        [TestMethod]
        public void CanAddQuestion()
        {
            _manager.Create(_alternativeManager,_sendQuestionManager, _subscribeManager, _question,_course,_alternatives);
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException))]
        public void TestEmptyFields()
        {
            _manager.Create(_alternativeManager, _sendQuestionManager, _subscribeManager, new Question(), _course, _alternatives);
        }
    }
}
