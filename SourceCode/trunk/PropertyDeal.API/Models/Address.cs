using System;

namespace PropertyDeal.API.Models
{
    public class Address
    {
        public virtual string Line1 { get; set; }
        
        public virtual string Line2 { get; set; }
        
        public virtual string Line3 { get; set; }

        public virtual string Landmark { get; set; }

        public virtual string Area { get; set; }
        
        public virtual string City { get; set; }
        
        public virtual string State { get; set; }
        
        public virtual Guid? CountryId { get; set; }//this is for Database save and get

        public virtual string Country { get; set; }//this is for showing Country Name on UI only
        
        public virtual string Pin { get; set; }
            
    }
}
