using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Web;

namespace ApiQuestionar.Auth
{
    public class ApiUserManager : UserManager<IdentityUser>
    {
        public ApiUserManager(IUserStore<IdentityUser> store) : base(store)
        {
            this.PasswordHasher = new PasswordHasher();
        }

        public override Task<IdentityUser> FindAsync(string userName, string password)
        {
            Task<IdentityUser> taskInvoke = Task<IdentityUser>.Factory.StartNew(() =>
            {
                var identity = Store.FindByNameAsync(userName).Result;
                if (identity == null)
                    throw new AuthenticationException();

                PasswordVerificationResult result = this.PasswordHasher.VerifyHashedPassword(identity.Password, password);
                if (result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    return identity;
                }

                throw new AuthenticationException();
            });
            return taskInvoke;
        }
    }
}