using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.113051, -84.56005, Taco Bell Woodstoc...", -84.56005)]
        [InlineData("33.24722, -84.273798, Taco Bell Griffi...", -84.273798)]
        [InlineData("33.27757,-84.291274,Taco Bell Griffin...", -84.291274)]
        [InlineData("30.357759,-87.163888,Taco Bell Gulf Breez...", -87.163888)]
        [InlineData("34.342547,-86.307539, Taco Bell Guntersvill...", -86.307539)]
        [InlineData("34.21147,-87.620375, Taco Bell Haleyvill...", -87.620375)]
        [InlineData("34.118399,-87.989494, Taco Bell Hamilto... ", -87.989494)]
        public void ParseLongitude(string line, double expected)
        {
            TacoParser parser = new TacoParser();
            var actual = parser.Parse(line).Location.Longitude;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.113051, -84.56005, Taco Bell Woodstoc...", 34.113051)]
        [InlineData("33.24722, -84.273798, Taco Bell Griffi...", 33.24722)]
        [InlineData("33.27757,-84.291274,Taco Bell Griffin...", 33.27757)]
        [InlineData("30.357759,-87.163888,Taco Bell Gulf Breez...", 30.357759)]
        [InlineData("34.342547,-86.307539, Taco Bell Guntersvill...", 34.342547)]
        [InlineData("34.21147,-87.620375, Taco Bell Haleyvill...", 34.21147)]
        [InlineData("34.118399,-87.989494, Taco Bell Hamilto... ", 34.118399)]
        public void ParseLatitude(string line, double expected)
        { 
            TacoParser parser = new TacoParser();
            var actual = parser.Parse(line).Location.Latitude;
            Assert.Equal(expected, actual);
        }

    }
}
