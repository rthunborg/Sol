using System;
using System.ComponentModel.DataAnnotations;

namespace SunnySeat.Core.Entities
{
    /// <summary>
    /// Represents weather data slices for cloud cover calculations
    /// </summary>
    public class WeatherSlice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Cloud cover percentage (0-100)
        /// </summary>
        [Range(0, 100)]
        public double CloudCoverPct { get; set; }

        [Required]
        [MaxLength(50)]
        public string Source { get; set; }

        /// <summary>
        /// Geographic location for weather data (PostGIS point)
        /// Using object for now - will be properly typed when PostGIS integration is complete
        /// </summary>
        public object Location { get; set; }

        /// <summary>
        /// Temperature in Celsius (optional)
        /// </summary>
        public double? TemperatureC { get; set; }

        /// <summary>
        /// Wind speed in m/s (optional)
        /// </summary>
        public double? WindSpeedMs { get; set; }

        public DateTime CreatedAt { get; set; }

        public WeatherSlice()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}