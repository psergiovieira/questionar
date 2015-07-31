using Infraestructure;
using Infraestructure.Business;
using Infraestructure.Types;
using Infraestructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Manager
{
    public class Example : IIdentity
    {
        public int Id { get; set; }
    }

    public class ExampleManager : Business<Example>
    {

        public ExampleManager(IRepository<Example> example, IUnitOfWork unitOfWork)
            : base(example, unitOfWork)
        {
        }

        public void Create()
        {
            Transaction(() =>
                {
                    Repository.Create(new Example());
                });
        }
    }
}
