using System;
using System.Collections.Generic;
using PropertyDeal.Core.Model;

namespace PropertyDeal.Core.Repository
{
    public interface IReadWriteRepository<T> : IQuerableRepository<T> where T : class , IEntity
    {
        void Add(T entity);
        void Add(IList<T> entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Func<T, Boolean> where);
    }
}
