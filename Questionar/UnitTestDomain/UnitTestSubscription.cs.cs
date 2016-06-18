
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UnitTestSubscription
    {
        private Mock<IRepository<Subscription>> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private SubscribeManager _manager;
        private Course _course;
        private User _student;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IRepository<Subscription>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _manager = new SubscribeManager(_mockRepository.Object, _mockUnitOfWork.Object);
            _student = new User() { Id = 1, IsTeacher = false, Name = "Professor", Active = true };
            _course = new Course()
            {
                Description = "Testes",
                Name = "Matematica",
                Id = 1,
                Created = new DateTime(2016, 01, 01),
                Teacher = _student
            };
        }

        [TestMethod]
        public void TestMapping()
        {
            var test = new NHibernateRepository<Subscription>(new NhibernateUnitOfWork()).GetAll();
        }

        [TestMethod]
        public void CanISubscribe()
        {
            _manager.Subscribe(_student, _course);
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException))]
        public void CanISubscribeTwotimes()
        {
            var subscriptions = new List<Subscription> { new Subscription { Course = _course, Student = _student } };

            _mockRepository.Setup(x => x.Query(null, null)).Returns(subscriptions.AsQueryable());
            _manager.Subscribe(_student, _course);
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException))]
        public void CanISubscribeLikeTeacher()
        {
            _student.IsTeacher = true;
            _manager.Subscribe(_student, _course);
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException))]
        public void CanISubscribeWithInativeUser()
        {
            _student.Active = false;
            _manager.Subscribe(_student, _course);
        }
    }
}
