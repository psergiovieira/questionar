using Infraestructure;
using Infraestructure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Manager
{
    public class Exemplo : IIdentity
    {
        public int Id { get; set; }
    }

    public class ExemploManager
    {
        private IRepository<Exemplo> _repository;

        public ExemploManager(IRepository<Exemplo> exemplo) 
        {
        }

        public void Create()
        {
            _repository.Create(new Exemplo());
        }
    }
}
