using Data.Security;
using Domain.Exceptions;
using Domain.Manager;
using Infraestructure;
using Infraestructure.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

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
            _manager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object);
            _user = new User
            {
                Id = 1,
                Name = "Paulo",
                UserName = "psvieira",
                Password = "123456",
                Created = new DateTime(2015, 1, 10),
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

        [TestMethod]
        public void CanAddUser()
        {
            _manager.Create(_user);
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException))]
        public void TestEmptyFields()
        {
            _manager.Create(new User());
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException), "Nome de usuário já registrado, por favor informe um Nome de usuário válido!")]
        public void TestUserNameRepeated()
        {
            var user = new User() { UserName = _user.UserName, Active = true };
            List<User> users = new List<User>() { user };
            _mockRepository.Setup(x => x.Query(null, null)).Returns(users.AsQueryable());

            _manager.Create(_user);
        }

        [TestMethod]
        [ExpectedException(typeof(QuestionarException), "E-mail já cadastrado, por favor informe um email válido!")]
        public void TestUserEmailRepeated()
        {
            var user = new User() { Email = "psvieira.ti@gmail.com" , UserName = "otherUserName", Active = true};
            List<User> users = new List<User>() { user };
            _mockRepository.Setup(x => x.Query(null , null)).Returns(users.AsQueryable());

            _manager.Create(_user);
        }
    }
}
