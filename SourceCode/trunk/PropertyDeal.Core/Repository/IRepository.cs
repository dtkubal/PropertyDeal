using PropertyDeal.Core.Model;
using PropertyDeal.Core.Model.Impl;

namespace PropertyDeal.Core.Repository
{
    /// <summary>
    /// Interface for Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class , IEntity
    {
        
    }
}
