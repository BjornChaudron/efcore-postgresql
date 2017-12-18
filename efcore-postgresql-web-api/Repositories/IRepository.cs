using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcore_postgresql_web_api.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        List<T> GetAll();
    }
}
