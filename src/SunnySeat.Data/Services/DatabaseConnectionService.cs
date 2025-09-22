using System;
using System.Data.Common;
using Npgsql;
using SunnySeat.Data.Context;

namespace SunnySeat.Data.Services
{
    /// <summary>
    /// Service for managing database connections and testing connectivity
    /// </summary>
    public class DatabaseConnectionService
    {
        private readonly string _connectionString;

        public DatabaseConnectionService(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// Test basic database connectivity
        /// </summary>
        /// <returns>True if connection successful</returns>
        public bool TestConnection()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    return connection.State == System.Data.ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                // Log the exception in a real implementation
                System.Diagnostics.Debug.WriteLine($"Database connection test failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Test PostGIS extension availability
        /// </summary>
        /// <returns>True if PostGIS is available</returns>
        public bool TestPostGisExtension()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT EXISTS(SELECT 1 FROM pg_extension WHERE extname = 'postgis');";
                        var result = command.ExecuteScalar();
                        return result != null && (bool)result;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"PostGIS extension test failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Create a new database context instance
        /// </summary>
        /// <returns>Configured database context</returns>
        public SunnySeatDbContext CreateContext()
        {
            return new SunnySeatDbContext(_connectionString);
        }

        /// <summary>
        /// Get database server version information
        /// </summary>
        /// <returns>Server version string or null if failed</returns>
        public string GetServerVersion()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    return connection.ServerVersion;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to get server version: {ex.Message}");
                return null;
            }
        }
    }
}