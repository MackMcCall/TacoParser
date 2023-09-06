using System;

namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogError("Missing information", null);
                return null;
            }

            double locationLatitude = double.Parse(cells[0]);

            double locationLongitude = double.Parse(cells[1]);

            string locationName = cells[2];

            TacoBell restaurant = new TacoBell()
            {
                Name = locationName,
                Location = new Point() { Latitude = locationLatitude, Longitude = locationLongitude }
            };

            return restaurant;
        }
    }
}