using System;
using System.Collections.Generic;
using System.Text;

namespace PortAdminstation
{
    public class MotorBoat : Boat
    {
        string IdPrefix = "M-";
        public MotorBoat()
        {
            BoatType = "Motorboat";
            BoatId = IdPrefix + GetGeneratedID();
            PlaceTakes =1.0;
            NumOfDaysParkedInPort = 3;


        }
    }
}
