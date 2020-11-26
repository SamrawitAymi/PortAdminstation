using System;
using System.Collections.Generic;
using System.Text;

namespace PortAdminstation
{
    public class Boat
    {
        public string BoatType { get; set; }
        public string BoatId { get; set; }
        public double PlaceTakes { get; set; }
        public int CurrentPlaceId { get; set; }
        public int NumOfDaysParkedInPort { get; set; }



        public static string GetGeneratedID() //Generate Boat Id
        {

            string[] charLength = new string[3];
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                int number = random.Next(0, 26);
                char alphabet = (char)('a' + number);
                string svaret = alphabet.ToString();
                charLength[i] = svaret.ToUpper();

            }
            string toReturn = null;
            foreach (string item in charLength)
            {
                toReturn += item;
            }

            return toReturn.ToUpper();
        }
      
    }
}
