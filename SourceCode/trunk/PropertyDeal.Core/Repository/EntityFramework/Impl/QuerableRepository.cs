using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using PropertyDeal.Core.Model;

namespace PropertyDeal.Core.Repository.EntityFramework.Impl
{
    public class QuerableRepository<T> : BaseRepository<T>, IQuerableRepository<T> where T :class ,IEntity
    {
        protected QuerableRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public T GetById(object Id)
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(KeyName);
            ParameterExpression pe = Expression.Parameter(typeof(T), KeyName);
            MemberExpression me = Expression.MakeMemberAccess(pe, propertyInfo);
            ConstantExpression ce = Expression.Constant(Id);
            BinaryExpression be = Expression.Equal(me, ce);
            return CurrentEntitySet.Where(Expression.Lambda<Func<T, bool>>(be, new[] { pe })).FirstOrDefault();
        }

        public T Get(Func<T, bool> where)
        {
            return CurrentEntitySet.Where(where).FirstOrDefault<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return CurrentEntitySet.ToList();

        }

        public IEnumerable<T> GetMany(Func<T, bool> where, int page, int resultPerPage)
        {
            return CurrentEntitySet.Where(where).Skip((page - 1) * resultPerPage).Take(resultPerPage).ToList();
        }

        public IList<T> GetMany(Expression<Func<T, Boolean>> where, Expression<Func<T, String>> orderExpression, int page, int resultPerPage, bool sortInAscendingOrder = true)
        {
            IQueryable<T> queryable = DataContext.Set<T>();

            if (where != null)
                queryable = queryable.Where(where);

            if (orderExpression != null)
                queryable = sortInAscendingOrder
                    ? queryable.OrderBy(orderExpression) : queryable.OrderByDescending(orderExpression);

            if (page > 0)
                queryable = queryable.Skip((page - 1) * resultPerPage);

            if (resultPerPage > 0)
                queryable = queryable.Take(resultPerPage);

            return queryable.ToList();

        }

        public int GetCount(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> queryable = DataContext.Set<T>().AsNoTracking();

            if (where != null)
                queryable = queryable.Where(where);

            return queryable.Count();
        }

        public IList<T> GetMany(Expression<Func<T, Boolean>> where)
        {
            IQueryable<T> queryable = DataContext.Set<T>();

            if (where != null)
                queryable = queryable.Where(where);
            return queryable.ToList();

        }


    }
}
