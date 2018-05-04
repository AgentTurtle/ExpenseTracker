using System.Data.Entity;

namespace ExpenseTrackerTron.Models
{
    public class ExpenseTrackerTronContext : DbContext
    {    
        public ExpenseTrackerTronContext() : base("name=ExpenseTrackerTronContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}