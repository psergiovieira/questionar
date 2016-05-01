using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Types;

namespace Infraestructure
{
    public interface IRepository<T> where T : IIdentity
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        IQueryable<TEntity> Query<TEntity>();
    }
}
