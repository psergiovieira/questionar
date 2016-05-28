using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Manager;
using Infraestructure.UnitOfWork;
using Infraestructure.Repository;
using Data;
using Data.Security;
using NHibernate.Linq;
using System.Linq;
using Infraestructure;
using Moq;

namespace UnitTestDomain
{
    [TestClass]
    public class UnitTestUser
    {
        private Mock<IRepository<User>> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private UserManager _manager;
        private User _user;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IRepository<User>>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _manager = new UserManager(_mockRepository.Object,_mockUnitOfWork.Object);
            _user = new User
            {
                Id = 1,
                Name = "Paulo",
                UserName = "psvieira",
                Password = "123456",
                Created = new DateTime(2015,1,10),
                Active = true,
                IsTeacher = false,
                Email = "psvieira.ti@gmail.com"
            };
        }

        [TestMethod]
        public void CanGetUser()
        {
            _mockRepository.Setup(x => x.GetById(1)).Returns(_user);

            var user = _manager.Repository.GetById(1);

            Assert.AreEqual(user, _user);
        }
    }
}
