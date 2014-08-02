using System.Data.Entity;

namespace PropertyDeal.Core.Repository.EntityFramework.Impl
{
    public class DBFactory : IDBFactory
    {

        private PropertyDealDbContext dataContext;


        public DBFactory()
        {

            Database.SetInitializer<PropertyDealDbContext>(null);
        }


        #region IDBFactory Members

        public PropertyDealDbContext GetDataBaseContext()
        {
            return dataContext ?? (dataContext = new PropertyDealDbContext());
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }

        #endregion
    }
}
