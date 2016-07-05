
using Data.Security;
using System;

namespace Data
{
    public class Course : Infraestructure.Types.IIdentity
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User Teacher { get; set; }

        public virtual DateTime Start { get; set; }
    }
}
