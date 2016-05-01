using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Manager;
using Infraestructure.UnitOfWork;
using Infraestructure.Repository;
using Data;
using Data.Security;
using NHibernate.Linq;
using System.Linq;

namespace UnitTestDomain
{
    [TestClass]
    public class UnitTestUser
    {
        [TestMethod]
        public void GetUser()
        {
            var _unitOfWork = new NhibernateUnitOfWork();
            var _repository = new NHibernateRepository<User>(_unitOfWork);
            var _manager = new UserManager(_repository, _unitOfWork);
            var user = _manager.Repository.GetById(1);
            Assert.AreEqual("paulo", user.Name);
        }
    }
}
