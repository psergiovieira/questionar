using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Infraestructure.UnitOfWork;
using Infraestructure.Repository;
using Data.Security;
using System.Security.Authentication;

namespace ApiQuestionar.Auth
{
    public class UserStore<TUser> : IUserRoleStore<TUser> where TUser : IdentityUser, new()
    {
        private Domain.Manager.UserManager _manager;
        Task IUserRoleStore<TUser, string>.AddToRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public UserStore()
        {
            var _unitOfWork = new NhibernateUnitOfWork();
            var _repository = new NHibernateRepository<User>(_unitOfWork);
            var _manager = new Domain.Manager.UserManager(_repository, _unitOfWork);
        }

        Task IUserStore<TUser, string>.CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<TUser, string>.DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        Task<TUser> IUserStore<TUser, string>.FindByIdAsync(string userId)
        {
            Task<TUser> taskInvoke = Task<TUser>.Factory.StartNew(() =>
            {
                User user = _manager.Repository.GetById(int.Parse(userId));
                if (user == null)
                    throw new AuthenticationException();

                IdentityUser usuarioSistema = new IdentityUser()
                {
                    UserName = user.Name,
                    Password = user.Password,
                    Id = user.Id.ToString()
                };

                return (TUser)usuarioSistema;
            });
            return taskInvoke;
        }

        Task<TUser> IUserStore<TUser, string>.FindByNameAsync(string userName)
        {
            Task<TUser> taskInvoke = Task<TUser>.Factory.StartNew(() =>
            {
                var user = _manager.Repository.Query<User>().FirstOrDefault(x => x.Name.ToUpper() == userName.ToUpper());
                if (user == null)
                    return null;

                IdentityUser usuarioSistema = new IdentityUser()
                {
                    UserName = user.Name,
                    Password = user.Password,
                    Id = user.Id.ToString()
                };

                return (TUser)usuarioSistema;
            });
            return taskInvoke;
        }

        Task<IList<string>> IUserRoleStore<TUser, string>.GetRolesAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRoleStore<TUser, string>.IsInRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        Task IUserRoleStore<TUser, string>.RemoveFromRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<TUser, string>.UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UserStore() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}