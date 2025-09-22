using System;
using System.ComponentModel.DataAnnotations;

namespace SunnySeat.Core.Entities
{
    /// <summary>
    /// Represents building footprints for shadow calculations
    /// </summary>
    public class Building
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Building footprint as PostGIS polygon
        /// Using object for now - will be properly typed when PostGIS integration is complete
        /// </summary>
        public object Polygon { get; set; }

        /// <summary>
        /// Building height in meters
        /// </summary>
        public double HeightM { get; set; }

        [MaxLength(50)]
        public string Source { get; set; }

        /// <summary>
        /// Number of floors (used for height estimation when HeightM is derived)
        /// </summary>
        public int? Floors { get; set; }

        [MaxLength(100)]
        public string BuildingType { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Building()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}