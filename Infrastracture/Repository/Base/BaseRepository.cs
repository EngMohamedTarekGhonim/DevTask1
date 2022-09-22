using Core.Interface.BaseRepository;
using Core.Entities.Base;
using Infrastracture.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repository.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly AppDataContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public BaseRepository(AppDataContext AppDataContext)
        {
            context = AppDataContext;
            entities = context.Set<T>();
        }
        //public IEnumerable<T> All()
        //{
        //    return entities.AsEnumerable();
        //}

        public IQueryable<T> All(params Expression<Func<T, object>>[] includes)
        {
            IIncludableQueryable<T, object> query = null;

            if (includes.Length > 0)
            {
                query = entities.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? entities : (IQueryable<T>)query;
        }


        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Find(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }


    }

}
