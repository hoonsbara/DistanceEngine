using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace DistanceEngine.Test
{
    [TestFixture]
    public class DistanceManagerTest
    {
        private DistanceManager _distanceEngine;
        private Mock<IDictionary<string, Location>> _locations;

        [SetUp]
        public void Init()
        {
            _locations = new Mock<IDictionary<string, Location>>(MockBehavior.Strict);
        }

        [Test]
        [TestCase("A-B3")]
        [TestCase("A-B-3")]
        [TestCase("A3")]
        [TestCase("AB3")]
        public void AddPath_WithWrongFormatOfPattern_ShouldNotAddInLocations(string route)
        {
            // Arrange
            _distanceEngine = new DistanceManager(_locations.Object);

            // Act
            _distanceEngine.AddPath(route);

            // Assert
            _locations.Verify(dic => dic.Add(It.IsAny<KeyValuePair<string, Location>>()), Times.Never());
        }

        [Test]
        [TestCase("AB5")]
        [TestCase("BC4")]
        [TestCase("DE4")]
        public void AddPath_WithRightFormatOfPattern_ShouldAddInLocations(string route)
        {
            // Arrange
            _distanceEngine = new DistanceManager(_locations.Object);

            // Act
            _distanceEngine.AddPath(route);

            // Assert
            _locations.Verify(dic => dic.Add(It.IsAny<KeyValuePair<string, Location>>()), Times.Once);
        }

        [Test]
        public void AddPath_WhenExistSameLocation_ShouldNotAddInLocations(string route)
        {
            // Arrange
            _distanceEngine = new DistanceManager(_locations.Object);

            const string locationName = "A";
            _locations.Setup(dic => dic.ContainsKey(locationName)).Returns(true);

            // Act
            _distanceEngine.AddPath(locationName);

            // Assert
            _locations.Verify(dic => dic.Add(It.IsAny<KeyValuePair<string, Location>>()), Times.Never());
        }

        public static Dictionary<string, Location> GenerateSampleLocations()
        {
            // locations
            var locationA = new Location("A");
            var locationB = new Location("B");
            var locationC = new Location("C");
            var locationD = new Location("D");
            var locationE = new Location("E");

            // paths
            locationA.Paths.Add(new Path(locationB, 5));
            locationA.Paths.Add(new Path(locationD, 5));
            locationA.Paths.Add(new Path(locationE, 7));

            locationB.Paths.Add(new Path(locationC, 4));

            locationC.Paths.Add(new Path(locationD, 8));
            locationC.Paths.Add(new Path(locationE, 2));

            locationD.Paths.Add(new Path(locationC, 8));
            locationD.Paths.Add(new Path(locationE, 6));

            locationE.Paths.Add(new Path(locationB, 3));

            //idctionary
            var locations=new Dictionary<string, Location>();
            locations.Add("A", locationA);
            locations.Add("B", locationB);
            locations.Add("C", locationC);
            locations.Add("D", locationD);
            locations.Add("E", locationE);

            return locations;
        }

        [Test]
        public void GetDistance_WhenRouteABC_ShouldReturnNine()
        {
            // Arrange
            _distanceEngine = new DistanceManager(GenerateSampleLocations());
            var route = new List<string> {"A", "B", "C"};
            const string expected = "9";

            // Act
            var result = _distanceEngine.GetDistance(route);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetDistance_WhenRouteAED_ShouldReturnNotSuchARoute()
        {
            // Arrange
            _distanceEngine = new DistanceManager(GenerateSampleLocations());
            var route = new List<string> { "A", "E", "D" };
            const string expected = "NOT SUCH ROUTE";

            // Act
            var result = _distanceEngine.GetDistance(route);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetPathNumber_WhenRouteFromCtoC_ShouldReturnTwo()
        {
            // Arrange
            _distanceEngine = new DistanceManager(GenerateSampleLocations());
            const string routeFrom = "C";
            const string routeTo = "C";
            const string expected = "2";

            // Act
            var result = _distanceEngine.GetPathNumber(routeFrom, routeTo);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetShortestLength_WhenRouteFromAtoC_ShouldReturnNine()
        {
            // Arrange
            _distanceEngine = new DistanceManager(GenerateSampleLocations());
            const string routeFrom = "A";
            const string routeTo = "C";
            const string expected = "9";

            // Act
            var result = _distanceEngine.GetShortestLength(routeFrom, routeTo);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
