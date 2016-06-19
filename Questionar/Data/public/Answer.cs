
using Data.Security;
using System;

namespace Data
{
    public class Answer : Infraestructure.Types.IIdentity
    {
        public virtual int Id { get; set; }

        public virtual Alternative Alternative { get; set; }

        public virtual User Student { get; set; }

        public virtual DateTime Created { get; set; }
    }
}
