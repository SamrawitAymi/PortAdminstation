using System;
using System.Collections.Generic;

namespace PortAdminstation
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 1;
            double TotalParkingPlace = 25;
            double BookedPortPlaces = 0;



            //Create port and boat parking places
            Port port = new Port();
            port.BoatPlaces = new List<ParkingLot>();

            int boatsComeEveryDay = 4;
            Random random = new Random();
            //Console.WriteLine("Press any key to switch to the next day");
            Console.ReadLine();

            //List of created Boats, boats on way to come and boats not in location
            List<Boat> createBoats = new List<Boat>();
            List<Boat> boatsOnWay = new List<Boat>();
            List<Boat> boatOutParkedPlace = new List<Boat>();

            Console.WriteLine("Press any key to show Port parking");
            do
            {
                DailyComingBoats(createBoats, random, boatsComeEveryDay);
                //Create parking plats
                Console.WriteLine("Parking No." + "\t\t\t" + "Boat" + "\t\t\t" + "typ");
                CreateBookingPlace(TotalParkingPlace, BookedPortPlaces, port, createBoats, boatsOnWay, boatOutParkedPlace);

                int NumberOfCargoBoat, numberOfSailBoat, numberOfMotorboat;
                double placeNumber;
                //Show number of boats that is created 
                GetParkingPlace(port, boatsOnWay, out placeNumber, out numberOfMotorboat, out numberOfSailBoat, out NumberOfCargoBoat);
                //Show free parking place
                GetFreeParkingPlats(placeNumber);

                //Get number of days that Boats parked in the port
                GetNumberOfDaysInPort(ref BookedPortPlaces, boatsOnWay, ref numberOfMotorboat, ref numberOfSailBoat, ref NumberOfCargoBoat);


                Console.WriteLine();

                Console.WriteLine($"Number of Motor Boat: {numberOfMotorboat}\nNumber of Sail Boat: {numberOfSailBoat}\n Number of Cargo Ship: {NumberOfCargoBoat}");

                // show parking place not fit for boats plats
                Console.WriteLine("Boats that do not fit any place:");
                GetBoatOutParkedPlace(boatOutParkedPlace);

                createBoats.Clear();
                boatOutParkedPlace.Clear();

                day++;

                Console.WriteLine();
                Console.WriteLine("Press any key to switch to the next day");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    Console.Clear();
            } while (true);
            }

        #region DailyComingBoats
        private static void DailyComingBoats(List<Boat> createBoats, Random random, int boatsComeEveryDay)
        {
            for (int i = 0; i < boatsComeEveryDay; i++)
            {
                int randomNum = random.Next(1, 3);
              
                if (randomNum == 1)
                {
                    MotorBoat motorBoat = new MotorBoat();
                    createBoats.Add(motorBoat);
                    if(motorBoat.PlaceTakes == 1)
                    {
                        createBoats.Add(motorBoat);
                    }
                }
                else if (randomNum == 2)
                {
                    SailBoat sailBoat = new SailBoat();
                    createBoats.Add(sailBoat);
                }
                else if (randomNum == 3)
                {
                    CargoShip cargoShip = new CargoShip();
                    createBoats.Add(cargoShip);
                }
                 
            }
        }
        #endregion

        #region CreateParkingPlace
        private static double CreateBookingPlace(double TotalParkingPlace, double BookedPortPlaces, Port port, List<Boat> createBoats, List<Boat> boatsOnWay, List<Boat> boatOutParkedPlace)
        {
            
  
           
            foreach (var item in createBoats)
            {
                Console.WriteLine(item.CurrentPlaceId + "\t\t\t" + item.BoatType + "\t\t\t"+item.BoatId);

                if ((BookedPortPlaces + item.PlaceTakes) <= TotalParkingPlace)
                {
                    BookedPortPlaces += item.PlaceTakes;

                    int parkingLot = 1;

                    item.CurrentPlaceId = parkingLot;

                    boatsOnWay.Add(item);

                    port.BoatPlaces.Add(new ParkingLot { ID = parkingLot, ParkingLotSize = item.PlaceTakes, IsBooked = true });
                }

                else
                {
                    boatOutParkedPlace.Add(item);
                }
            }

            return BookedPortPlaces;
        }
        #endregion

        #region GetParkingPlace
        private static void GetParkingPlace(Port port, List<Boat> boatOnWay, out double placeNumber, out int numberOfMotorboat, out int numberOfSailBoat, out int NumberOfCargoBoat)
        {
            foreach (var items in port.BoatPlaces)
            {
                foreach (var item in boatOnWay)
                {
                    if (item.PlaceTakes == item.PlaceTakes);
                }
            }

            placeNumber = 1;
            numberOfMotorboat = 0;
            numberOfSailBoat = 0;
            NumberOfCargoBoat = 0;
          
           // Console.WriteLine("PlaceNo\t\t\tBoatType\t\t\tBoatNummer");

            foreach (Boat item in boatOnWay.ToArray())
            {

                if (item != null)
                {
                    if (item.PlaceTakes > 1)
                    {
                        Console.WriteLine($"{placeNumber}-{placeNumber + item.PlaceTakes - 1}\t\t\t {item.BoatType}\t\t\t { item.BoatId}");

                        placeNumber++;
                    }
                    else
                    {
                        Console.WriteLine($"{placeNumber}-{placeNumber + item.PlaceTakes - 1}.\t\t\t{item.BoatType}\t\t\tt{item.BoatId}");
                    }
                    
                    if (item is MotorBoat)
                    {
                        numberOfMotorboat++;
                        placeNumber += item.PlaceTakes;
                    }
                    else if (item is SailBoat)
                    {
                        numberOfSailBoat++;
                        placeNumber += item.PlaceTakes - 1;
                    }
                    else if (item is CargoShip)
                    {
                        NumberOfCargoBoat++;
                        placeNumber += item.PlaceTakes - 1;
                    }
                }
                else
                {
                    Console.WriteLine(placeNumber + "Free Place");
                    placeNumber++;
                }
            }
        }

        #endregion

        #region GetFreeParkingPlats
        private static double GetFreeParkingPlats(double placeNumber)
        {
            if (placeNumber < 25)
            {
                double FreePlaces = 25 - placeNumber;

                for (int i = 0; i < FreePlaces; i++)
                {
                    Console.WriteLine($"{placeNumber} \t\t\t Free Plats");

                    placeNumber++;
                }

            }
            return placeNumber;
        }
        #endregion

        #region GetNumberOfDaysInPort
        private static void GetNumberOfDaysInPort(ref double BookedPortPlaces, List<Boat> boatsOnWay, ref int numberOfMotorboats, ref int numberOfSailBoats, ref int numberOfCargoBoat)
        {
            foreach (var item in boatsOnWay.ToArray())
            {
                if (item != null)
                {
                    if (item.NumOfDaysParkedInPort != 0)
                    {
                       
                        item.NumOfDaysParkedInPort--;
                    }

                    else
                    {
                        Console.WriteLine($"The boat leaving the harbor: {item.BoatId}");
 
                        if (item is MotorBoat)
                            numberOfMotorboats--;
                        else if (item is SailBoat)
                            numberOfSailBoats--;
                        else if (item is CargoShip)
                            numberOfCargoBoat--;
                        BookedPortPlaces -= item.PlaceTakes;
                        boatsOnWay.Remove(item);
                    }
                }
            }
        }
        #endregion

        #region GetTheBoatOutParkedPlace
        private static void GetBoatOutParkedPlace(List<Boat> boatOutParkedPlace)
        {
            foreach (var item in boatOutParkedPlace)
            {
                Console.WriteLine($"{item.BoatType} ID number: {item.BoatId}");
                
            }
        }
        #endregion


    }
}
