using System;
using System.ComponentModel.DataAnnotations;

namespace SunnySeat.Core.Entities
{
    /// <summary>
    /// Represents a venue (restaurant, cafe, etc.) that may have outdoor seating
    /// </summary>
    public class Venue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Geographic location as PostGIS point (will be configured in Entity Framework)
        /// Using object for now - will be properly typed when PostGIS integration is complete
        /// </summary>
        public object Location { get; set; }

        [MaxLength(100)]
        public string District { get; set; }

        public int? PriceLevel { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Website { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Venue()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}