using Data.Security;
using Domain.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiQuestionar.Controllers
{
    public class UserController : BaseController<User>
    {
        private UserManager _manager;
        public UserController()
        {
            _manager = new UserManager(Repository, UnitOfWork);
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Post(User user)
        {
            _manager.Create(user);
            return Ok("Usuário cadastrado com sucesso!");
        }
    }
}