
using Data.Security;
using System;

namespace Data
{
    public class Alternative : Infraestructure.Types.IIdentity
    {
        public virtual int Id { get; set; }

        public virtual Question Question { get; set; }

        public virtual string Description { get; set; }

        public virtual Int32 Order { get; set; }

        public virtual bool IsCorrect { get; set; }
    }
}
