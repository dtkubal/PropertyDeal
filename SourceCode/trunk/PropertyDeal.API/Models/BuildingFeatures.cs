using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyDeal.API.Models
{
    public class BuildingFeatures : Features
    {
        public bool InternetWiFiConnectivity { get; set; }

        public bool VisitorParking { get; set; }
        
        public bool SwimmingPool { get; set; }

        public bool Waterstorage { get; set; }

        public bool IntercomFacility { get; set; }

        public bool SecurityPersonnel { get; set; }

        public bool MaintenanceStaff { get; set; }

        public bool Park { get; set; }

        public bool PipedGas { get; set; }


    }
}
