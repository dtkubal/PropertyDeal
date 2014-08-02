using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PropertyDeal.Core.Repository.EntityFramework
{
    public class PropertyDealDbContext : DbContext
    {
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
