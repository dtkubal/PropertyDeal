using System;

namespace PropertyDeal.Core.Model.Impl
{
    public class Entity : IEntity
    {
        public virtual Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.Empty;
        }

    }
}
