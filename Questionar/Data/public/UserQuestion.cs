
using Data.Security;
using System;

namespace Data
{
    public class UserQuestion : Infraestructure.Types.IIdentity
    {
        public virtual int Id { get; set; }

        public virtual Question Question { get; set; }

        public virtual User User { get; set; }

        public virtual DateTime Created { get; set; }
    }
}
