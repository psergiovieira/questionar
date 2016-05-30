using Infraestructure.Types;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Infraestructure
{
    public interface IRepository<T> where T : IIdentity
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        IQueryable<T> Query(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}
