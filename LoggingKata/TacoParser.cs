

namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                logger.LogWarning($"Something went wrong, not enough info. Line = {line}");
                return null;
            }
            var lat = double.Parse(cells[0]);
            var longit = double.Parse(cells[1]);
            var name = cells[2];
            var point = new Point();
            point.Latitude = lat;
            point.Longitude = longit;
            var tacoBell = new TacoBell()
            {
                Name = name,
                Location = point
            };

            return tacoBell;
        }
    }
}