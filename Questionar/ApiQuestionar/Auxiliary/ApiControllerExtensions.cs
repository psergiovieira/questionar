using Data.Security;
using Infraestructure.Repository;
using Infraestructure.UnitOfWork;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace ApiQuestionar.Auxiliary
{
    public static class ApiControllerExtensions
    {
        public static User GetUser(this ApiController controller)
        {
            var repository = new NHibernateRepository<User>(new NhibernateUnitOfWork());
            return repository.GetById(int.Parse(controller.User.Identity.GetUserId()));
        }
    }
}