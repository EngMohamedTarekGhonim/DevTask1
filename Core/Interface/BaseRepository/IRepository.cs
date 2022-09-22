using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.BaseRepository
{
    public interface IRepository<T> where T : BaseModel
    {
        T Find(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        public IQueryable<T> All(params Expression<Func<T, object>>[] includes);
    }

}
