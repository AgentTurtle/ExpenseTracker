using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerTron.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        // Navigation property
        public Category Category { get; set; }
    }
}