
using Data.Security;
using System;

namespace Data
{
    public class Question : Infraestructure.Types.IIdentity
    {
        public virtual int Id { get; set; }

        public virtual Course Course { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Sent { get; set; }
    }
}
