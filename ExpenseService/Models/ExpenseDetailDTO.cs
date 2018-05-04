using System;

namespace ExpenseTrackerTron.Models
{
    public class ExpenseDetailDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
    }
}