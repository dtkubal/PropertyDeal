using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PropertyDeal.Core.Model;

namespace PropertyDeal.Core.Repository
{
    public interface IQuerableRepository<T> where T : class , IEntity
    {
        T GetById(object Id);
        T Get(Func<T, Boolean> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Func<T, bool> where, int page, int resultPerPage);
        IList<T> GetMany(Expression<Func<T, Boolean>> where, Expression<Func<T, String>> orderExpression, int page,
                               int resultPerPage, bool sortInAscendingOrder = true);
        IList<T> GetMany(Expression<Func<T, Boolean>> where);
        int GetCount(Expression<Func<T, bool>> condition = null);

    }
}
