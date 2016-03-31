using Data;
using Data.Security;
using Infraestructure;
using Infraestructure.Business;
using Infraestructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Manager
{
    public class UserManager : Business<User>
    {
        public UserManager(IRepository<User> user, IUnitOfWork unitOfWork)
            : base(user, unitOfWork)
        {
        }
    }
}
