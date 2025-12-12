using System.ComponentModel.DataAnnotations;

namespace sw_project.Models
{
    public class Expense
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive number.")]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        public string Category { get; set; } = null!;

        // Ownership: which user created/owns this expense
        public string? UserId { get; set; }

    }
}