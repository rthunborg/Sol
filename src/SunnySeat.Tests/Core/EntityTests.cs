using NUnit.Framework;
using System;
using SunnySeat.Core.Entities;

namespace SunnySeat.Tests.Core
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void Venue_Constructor_SetsDefaultValues()
        {
            // Act
            var venue = new Venue();

            // Assert
            Assert.IsNotNull(venue);
            Assert.That(venue.CreatedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
            Assert.That(venue.UpdatedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
        }

        [Test]
        public void Venue_Properties_CanBeSetAndRetrieved()
        {
            // Arrange
            var venue = new Venue();
            var testName = "Test Venue";
            var testDistrict = "Test District";

            // Act
            venue.Name = testName;
            venue.District = testDistrict;
            venue.PriceLevel = 2;

            // Assert
            Assert.AreEqual(testName, venue.Name);
            Assert.AreEqual(testDistrict, venue.District);
            Assert.AreEqual(2, venue.PriceLevel);
        }

        [Test]
        public void Patio_Constructor_SetsDefaultValues()
        {
            // Act
            var patio = new Patio();

            // Assert
            Assert.IsNotNull(patio);
            Assert.That(patio.CreatedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
            Assert.That(patio.UpdatedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(0.5, patio.QualityFlag); // Default medium quality
        }

        [Test]
        public void Building_Constructor_SetsDefaultValues()
        {
            // Act
            var building = new Building();

            // Assert
            Assert.IsNotNull(building);
            Assert.That(building.CreatedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
            Assert.That(building.UpdatedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
        }

        [Test]
        public void Prediction_Constructor_SetsDefaultValues()
        {
            // Act
            var prediction = new Prediction();

            // Assert
            Assert.IsNotNull(prediction);
            Assert.That(prediction.GeneratedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
            Assert.AreEqual(1, prediction.AlgorithmVersion);
        }

        [Test]
        public void WeatherSlice_Constructor_SetsDefaultValues()
        {
            // Act
            var weatherSlice = new WeatherSlice();

            // Assert
            Assert.IsNotNull(weatherSlice);
            Assert.That(weatherSlice.CreatedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
        }

        [Test]
        public void Feedback_Constructor_SetsDefaultValues()
        {
            // Act
            var feedback = new Feedback();

            // Assert
            Assert.IsNotNull(feedback);
            Assert.That(feedback.CreatedAt, Is.EqualTo(DateTime.UtcNow).Within(TimeSpan.FromSeconds(1)));
        }

        [Test]
        public void WeatherSlice_CloudCoverPct_AcceptsValidRange()
        {
            // Arrange
            var weatherSlice = new WeatherSlice();

            // Act & Assert - Valid values
            weatherSlice.CloudCoverPct = 0;
            Assert.AreEqual(0, weatherSlice.CloudCoverPct);

            weatherSlice.CloudCoverPct = 50;
            Assert.AreEqual(50, weatherSlice.CloudCoverPct);

            weatherSlice.CloudCoverPct = 100;
            Assert.AreEqual(100, weatherSlice.CloudCoverPct);
        }
    }
}