using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using PropertyDeal.Core.Model;

namespace PropertyDeal.Core.Repository.EntityFramework.Impl
{
    public class ReadWriteRepository<T> : QuerableRepository<T>, IReadWriteRepository<T> where T : class , IEntity
    {
        protected ReadWriteRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public void Add(T entity)
        {

            CurrentEntitySet.Add(entity);
        }

        public void Add(IList<T> entity)
        {
            foreach (var entToAdd in entity)
            {
                CurrentEntitySet.Add(entToAdd);
            }
        }

        public void Update(T entity)
        {

            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            CurrentEntitySet.Remove(entity);
        }

        public void Delete(Func<T, bool> where)
        {
            IEnumerable<T> objects = CurrentEntitySet.Where(where).AsEnumerable();
            foreach (T obj in objects)
                CurrentEntitySet.Remove(obj);
        }

    }
}
