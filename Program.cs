using System;
using System.Configuration;
using SunnySeat.Data.Services;

namespace Sol
{
    /// <summary>
    /// Console application for testing database connectivity and infrastructure
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sunny Seat - Database Infrastructure Test");
            Console.WriteLine("========================================");

            try
            {
                // Get connection string from config
                var connectionString = ConfigurationManager.ConnectionStrings["SunnySeatConnection"]?.ConnectionString;
                
                if (string.IsNullOrEmpty(connectionString))
                {
                    Console.WriteLine("? Connection string 'SunnySeatConnection' not found in App.config");
                    Console.WriteLine("Please configure the PostgreSQL connection string.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("?? Testing database connection...");
                var dbService = new DatabaseConnectionService(connectionString);

                // Test basic connectivity
                if (dbService.TestConnection())
                {
                    Console.WriteLine("? Database connection successful");
                    
                    // Get server version
                    var version = dbService.GetServerVersion();
                    if (!string.IsNullOrEmpty(version))
                    {
                        Console.WriteLine($"?? PostgreSQL Version: {version}");
                    }

                    // Test PostGIS extension
                    Console.WriteLine("???  Testing PostGIS extension...");
                    if (dbService.TestPostGisExtension())
                    {
                        Console.WriteLine("? PostGIS extension is available");
                    }
                    else
                    {
                        Console.WriteLine("??  PostGIS extension not found - spatial features will not work");
                    }
                }
                else
                {
                    Console.WriteLine("? Database connection failed");
                    Console.WriteLine("Please check your PostgreSQL server and connection string.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"? Error during testing: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}