using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace PropertyDeal.Core.Repository.EntityFramework.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBFactory _databaseFactory;
        private PropertyDealDbContext _dataContext;

        public UnitOfWork(IDBFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        protected PropertyDealDbContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.GetDataBaseContext()); }
        }


        #region IUnitOfWork Members

        public void Commit()
        {
            DataContext.Commit();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    DataContext.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            DataContext.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }



        #endregion
    }
}
