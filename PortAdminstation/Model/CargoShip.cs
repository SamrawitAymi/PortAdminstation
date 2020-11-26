using System;
using System.Collections.Generic;
using System.Text;

namespace PortAdminstation
{
    public class CargoShip: Boat
    {
        string IdPrefix = "C-";
        public CargoShip()
        {
            BoatType = "Cargo Ship";
            BoatId = IdPrefix + GetGeneratedID();
            PlaceTakes = 4.0;
            NumOfDaysParkedInPort = 6;
           
        }
    }
}
