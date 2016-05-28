using ApiQuestionar.Auth;
using Data.Security;
using Domain.Manager;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ApiQuestionar.Auth;

namespace ApiQuestionar.Controllers
{
    public class UserController : BaseController<User>
    {
        public ApiUserManager UserManagerAuth { get; private set; }

        private UserManager _manager;

        public UserController()
            : this(new ApiUserManager(new UserStore<IdentityUser>()))
        {
            _manager = new UserManager(Repository, UnitOfWork);
        }

        public UserController(ApiUserManager userManager)
        {
            UserManagerAuth = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Post(User user)
        {
            _manager.Create(user);
            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Login([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                throw new AuthenticationException();

            user.UserName = user.UserName.Replace(".", "").Replace("-", "");

            var response = await UserManagerAuth.FindAsync(user.UserName, user.Password);

            await SignInAsync(response, true);
            return Ok("Usuário autenticado com sucesso");
        }

        private async Task SignInAsync(IdentityUser identityUser, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            var identity = await UserManagerAuth.CreateIdentityAsync(identityUser, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// POST: /Autenticacao/LogOut
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize()]
        public IHttpActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Ok();
        }

        /// <summary>
        /// GET: /Autenticacao/IsLogged
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize()]
        public IHttpActionResult IsLogged()
        {
            var identity = UserManagerAuth.FindById<IdentityUser, string>(User.Identity.GetUserId());            
            var user = _manager.Repository.GetById(int.Parse(identity.Id));
            if (!user.Active)
            {
                LogOut();
                return NotFound();
            }

            return Ok();
        }

    }
}