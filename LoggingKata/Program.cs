using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            logger.LogInfo($"Sample Line: {lines[0]}");
            logger.LogInfo("Begin Parsing...");
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();
            ITrackable taco1 = new TacoBell();
            ITrackable taco2 = new TacoBell();
            double dist = 0.0;
            for (int i = 0; i <= locations.Length - 1; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate()
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude
                };

                for (int j = 0; j <= locations.Length - 1; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate()
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };

                    var currentDistance = corA.GetDistanceTo(corB);

                    if (currentDistance > dist)
                    {
                        dist = currentDistance;
                        taco1 = locA;
                        taco2 = locB;
                        logger.LogInfo($"New max distance found: {Math.Round(dist*0.00062,2)} miles!");
                    }
                }
            }

            Console.WriteLine($"\n{taco1.Name} and {taco2.Name} are furthest apart");
            Console.WriteLine($"They are {Math.Round(dist*0.00062, 2)} miles apart");

            
        }
    }
}
