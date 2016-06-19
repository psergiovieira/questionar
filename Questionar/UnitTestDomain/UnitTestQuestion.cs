using System;
using Data;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDomain
{
    [TestClass]
    public class UnitTestQuestion
    {
        [TestMethod]
        public void TestMapping()
        {
            var entity = new NHibernateRepository<Question>(new NhibernateUnitOfWork()).GetAll();
        }

    }
}
