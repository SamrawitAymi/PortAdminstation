using System;
using System.Collections.Generic;
using System.Text;

namespace PortAdminstation
{
    class Port
    {
       
            public double Size { get; set; }

            public List<ParkingLot> BoatPlaces { get; set; }

        }

        class ParkingLot
        {
            public double ParkingLotSize { get; set; }
            public int ID { get; set; }
            public bool IsBooked { get; set; }
           
    }
}
