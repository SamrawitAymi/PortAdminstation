﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PortAdminstation
{

    public class SailBoat: Boat
    {
        string IdPrefix = "L-";
        public SailBoat()
        {
            BoatType = "Cargo Ship";
            BoatId = IdPrefix + GetGeneratedID();
            PlaceTakes = 4.0;
            NumOfDaysParkedInPort = 6;

        }
    }
}