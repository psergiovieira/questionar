using Data;
using Domain.Exceptions;
using Domain.Manager;
using Infraestructure;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace UnitTestDomain
{
    [TestClass]
    public class UnitTestCourse
    {
        private Mock<IRepository<Course>> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private CourseManager _manager;
        private Course _course;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IRepository<Course>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _manager = new CourseManager(_mockRepository.Object, _mockUnitOfWork.Object);
            _course = new Course()
            {
                Description = "Testes",
                Name = "Matematica",
                Id = 1,
                Created = new DateTime(2016, 01, 01)
            };
        }

        [TestMethod]
        public void TestMapping()
        {
            var test = new NHibernateRepository<Course>(new NhibernateUnitOfWork()).GetAll();
        }

        [TestMethod]
        public void CanGetCourse()
        {
            _mockRepository.Setup(x => x.GetById(1)).Returns(_course);
            var course = _manager.Repository.GetById(1);
            Assert.AreEqual(_course, course);
        }

        [TestMethod]
        public void CanAddCourse()
        {
            _manager.Repository.Create(_course);
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException))]
        public void TestEmptyFields()
        {
            _manager.Create(new Course());
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException))]
        public void TestAddWithoutName()
        {
            _manager.Create(new Course(){Description = "Testes"});
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException))]
        public void TestAddWithoutDescription()
        {
            _manager.Create(new Course() { Name = "Testes" });
        }
    }
}
