using Infraestructure;
using Infraestructure.Types;
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

    public class ExampleManager
    {
        private IRepository<Example> _repository;

        public ExampleManager(IRepository<Example> example) 
        {
        }

        public void Create()
        {            
            _repository.Create(new Example());
        }
    }
}
