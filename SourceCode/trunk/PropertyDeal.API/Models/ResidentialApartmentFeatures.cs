using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyDeal.API.Models
{
    public class ResidentialApartmentFeatures : Features
    {

        public bool PowerBackup { get; set; }

        public bool VaastuCompliant { get; set; }

        public bool FengShui { get; set; }

        public bool Waterpurifier { get; set; }

        public bool IntercomFacility { get; set; }

        public bool Security { get; set; }

        public bool FireAlarm { get; set; }

        public bool AirConditioned { get; set; }

        public bool Lift { get; set; }
    }

}

