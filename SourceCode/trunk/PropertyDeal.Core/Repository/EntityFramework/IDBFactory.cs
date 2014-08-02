using System;

namespace PropertyDeal.Core.Repository.EntityFramework
{
    public interface IDBFactory : IDisposable
    {
        PropertyDealDbContext GetDataBaseContext();
    }
}
