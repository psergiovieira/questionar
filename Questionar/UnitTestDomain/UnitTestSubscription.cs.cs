
using Data;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDomain
{
    [TestClass]
    public class UnitTestSubscription
    {
        [TestMethod]
        public void TestMapping()
        {
            var test = new NHibernateRepository<Subscription>(new NhibernateUnitOfWork()).GetAll();
        }
    }
}
