using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnySeat.Core.Entities
{
    /// <summary>
    /// Represents a patio/outdoor seating area belonging to a venue
    /// </summary>
    public class Patio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VenueId { get; set; }

        /// <summary>
        /// Polygon geometry representing the patio area (PostGIS geometry)
        /// Using object for now - will be properly typed when PostGIS integration is complete
        /// </summary>
        public object Polygon { get; set; }

        [MaxLength(50)]
        public string Orientation { get; set; }

        /// <summary>
        /// Optional height override in meters (for shadow calculations)
        /// </summary>
        public double? HeightOverrideM { get; set; }

        /// <summary>
        /// Quality flag for polygon accuracy (0.0 to 1.0)
        /// </summary>
        public double QualityFlag { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Navigation property to parent venue
        /// </summary>
        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }

        public Patio()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            QualityFlag = 0.5; // Default medium quality
        }
    }
}