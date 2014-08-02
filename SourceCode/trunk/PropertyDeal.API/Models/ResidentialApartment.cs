using System;

namespace PropertyDeal.API.Models
{
    public class ResidentialApartment : ResidentialProperty
    {
        public int BedRoom { get; set; }

        public int BathRoom { get; set; }

        public double BuiltupArea { get; set; }

        public string Description { get; set; }

        public DateTime Possession { get; set; } // Date By which Possession can be given

        public ResidentialApartmentAddress Address { get; set; }

        public ResidentialApartmentFeatures ResidentialApartmentFeatures { get; set; }


       
    }
}
