using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Core;
using NUnit.Framework;

namespace DistanceEngine.Test
{
    [TestFixture]
    public class IntegrationTest
    {
        private DistanceManager _distanceEngine;

        [SetUp]
        public void Init()
        {
            _distanceEngine = new DistanceManager(new Dictionary<string, Location>());
            // Test Input: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7

            _distanceEngine.AddPath("AB5");
            _distanceEngine.AddPath("BC4");
            _distanceEngine.AddPath("CD8");
            _distanceEngine.AddPath("DC8");
            _distanceEngine.AddPath("DE6");
            _distanceEngine.AddPath("AD5");
            _distanceEngine.AddPath("CE2");
            _distanceEngine.AddPath("EB3");
            _distanceEngine.AddPath("AE7");
        }

        [Test]
        public void Question1_GetDistance_ABC_ShouldReturnNine()
        {
            // Arrange
            const string expected = "9";
            var routes = new List<string>(){ "A","B","C" };
            
            // Act
            var result = _distanceEngine.GetDistance(routes);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Question2_GetDistance_AEBCD_ShouldReturnTwentyTwo()
        {
            // Arrange
            const string expected = "22";
            var routes = new List<string>() { "A", "E", "B", "C", "D" };

            // Act
            var result = _distanceEngine.GetDistance(routes);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Question3_GetDistance_AED_ShouldReturnNoSuchRoute()
        {
            // Arrange
            const string expected = "NOT SUCH ROUTE";
            var routes = new List<string>() { "A", "E", "D"};

            // Act
            var result = _distanceEngine.GetDistance(routes);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Question4_GetPathNumber_CC_ShouldReturnTwo()
        {
            // Arrange
            const string expected = "2";
            const string from = "C";
            const string to = "C";

            // Act
            var result = _distanceEngine.GetPathNumber(from, to);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Question5_GetPathNumber_AC_ShouldReturnThree()
        {
            // Arrange
            const string expected = "3";
            const string from = "A";
            const string to = "C";

            // Act
            var result = _distanceEngine.GetPathNumber(from, to);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Question6_GetShortestRoute_AC_ShouldReturnNine()
        {
            // Arrange
            const string expected = "9";
            const string from = "A";
            const string to = "C";

            // Act
            var result = _distanceEngine.GetShortestLength(from, to);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Question7_GetShortestRoute_BB_ShouldReturnNine()
        {
            // Arrange
            const string expected = "9";
            const string from = "B";
            const string to = "B";

            // Act
            var result = _distanceEngine.GetShortestLength(from, to);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Question8_GetShortestRoute_CC_ShouldReturnNine()
        {
            // Arrange
            const string expected = "9";
            const string from = "C";
            const string to = "C";

            // Act
            var result = _distanceEngine.GetShortestLength(from, to);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
