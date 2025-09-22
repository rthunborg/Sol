using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnySeat.Core.Entities
{
    /// <summary>
    /// Represents user feedback on prediction accuracy
    /// </summary>
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VenueId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        [MaxLength(20)]
        public string ObservedState { get; set; } // "Sunny", "Partial", "Shaded"

        /// <summary>
        /// Confidence percentage that was shown to user when prediction was made
        /// </summary>
        [Range(0, 100)]
        public double ConfidenceAtPrediction { get; set; }

        /// <summary>
        /// User's IP address (hashed for privacy)
        /// </summary>
        [MaxLength(64)]
        public string UserIpHash { get; set; }

        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Navigation property to venue
        /// </summary>
        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }

        public Feedback()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}