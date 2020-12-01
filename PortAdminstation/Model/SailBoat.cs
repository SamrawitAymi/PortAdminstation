using System;
using System.Collections.Generic;
using System.Text;

namespace PortAdminstation
{

    public class SailBoat: Boat
    {
        string IdPrefix = "S-";
        public SailBoat()
        {
            BoatType = "Sailboat";
            BoatId = IdPrefix + GetGeneratedID();
            PlaceTakes = 2.0;
            NumOfDaysParkedInPort = 1;

        }
    }
}