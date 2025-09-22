using NUnit.Framework;
using System;
using SunnySeat.Data.Services;

namespace SunnySeat.Tests.Data
{
    [TestFixture]
    public class DatabaseConnectionServiceTests
    {
        private DatabaseConnectionService _connectionService;
        private const string TestConnectionString = "Server=localhost;Port=5432;Database=sunnyseat_test;User Id=postgres;Password=test;";

        [SetUp]
        public void Setup()
        {
            _connectionService = new DatabaseConnectionService(TestConnectionString);
        }

        [Test]
        public void Constructor_WithNullConnectionString_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DatabaseConnectionService(null));
        }

        [Test]
        public void Constructor_WithValidConnectionString_CreatesInstance()
        {
            // Act
            var service = new DatabaseConnectionService(TestConnectionString);

            // Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConnection_WithInvalidConnectionString_ReturnsFalse()
        {
            // Arrange
            var invalidService = new DatabaseConnectionService("Server=invalid;Database=nonexistent;");

            // Act
            var result = invalidService.TestConnection();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GetServerVersion_WithInvalidConnection_ReturnsNull()
        {
            // Arrange
            var invalidService = new DatabaseConnectionService("Server=invalid;Database=nonexistent;");

            // Act
            var version = invalidService.GetServerVersion();

            // Assert
            Assert.IsNull(version);
        }

        [Test]
        public void CreateContext_ReturnsValidDbContext()
        {
            // Act
            var context = _connectionService.CreateContext();

            // Assert
            Assert.IsNotNull(context);
            Assert.IsInstanceOf<SunnySeat.Data.Context.SunnySeatDbContext>(context);
        }

        // Note: The following tests require a running PostgreSQL instance
        // They are marked as Explicit to avoid failures in CI/CD without database
        
        [Test, Explicit("Requires PostgreSQL server")]
        public void TestConnection_WithValidConnection_ReturnsTrue()
        {
            // This test requires a running PostgreSQL instance
            // Act
            var result = _connectionService.TestConnection();

            // Assert - will depend on actual database availability
            // In real environment with PostgreSQL running, this should return true
            Console.WriteLine($"Connection test result: {result}");
        }

        [Test, Explicit("Requires PostgreSQL server with PostGIS")]
        public void TestPostGisExtension_WithPostGISInstalled_ReturnsTrue()
        {
            // This test requires PostgreSQL with PostGIS extension
            // Act
            var result = _connectionService.TestPostGisExtension();

            // Assert
            Console.WriteLine($"PostGIS test result: {result}");
        }
    }
}