using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore...", -86.841402)]
        [InlineData("34.8831,-84.293899,Taco Bell Blue Ridg...", -84.293899)]
        [InlineData("31.440529,-86.953648,Taco Bell Evergreen...", -86.953648)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);
        } 
        
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore...", 34.992219)]
        [InlineData("34.8831,-84.293899,Taco Bell Blue Ridg...", 34.8831)]
        [InlineData("31.440529,-86.953648,Taco Bell Evergreen...", 31.440529)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line).Location.Latitude;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
