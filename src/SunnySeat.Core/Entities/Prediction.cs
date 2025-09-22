using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnySeat.Core.Entities
{
    /// <summary>
    /// Represents precomputed sun window predictions for a patio on a specific date
    /// </summary>
    public class Prediction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatioId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// JSON array of sun windows (start-end time pairs) for the date
        /// Format: [{"start": "09:30", "end": "11:45"}, {...}]
        /// </summary>
        [Required]
        public string SunWindows { get; set; }

        public DateTime GeneratedAt { get; set; }

        /// <summary>
        /// Version of the prediction algorithm used
        /// </summary>
        public int AlgorithmVersion { get; set; }

        /// <summary>
        /// Navigation property to patio
        /// </summary>
        [ForeignKey("PatioId")]
        public virtual Patio Patio { get; set; }

        public Prediction()
        {
            GeneratedAt = DateTime.UtcNow;
            AlgorithmVersion = 1;
        }
    }
}