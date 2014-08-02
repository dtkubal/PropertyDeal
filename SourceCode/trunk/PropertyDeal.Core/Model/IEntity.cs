using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyDeal.Core.Model
{
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the id of the Entity.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        Guid Id { get; set; }
    }
}
