using System.Data.Entity;
using PropertyDeal.Core.Model;

namespace PropertyDeal.Core.Repository.EntityFramework.Impl
{
    public class BaseRepository<T> : IRepository<T> where T: class , IEntity
    {

        private PropertyDealDbContext _dataContext;
        private readonly IDbSet<T> dbset;
        private const string keyName = "Id";

        protected BaseRepository(IDBFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDBFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected IDbSet<T> CurrentEntitySet
        {
            get { return dbset; }
        }

        protected PropertyDealDbContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.GetDataBaseContext()); }
        }

        protected virtual string KeyName
        {

            get { return keyName; }
        }
    }
}
