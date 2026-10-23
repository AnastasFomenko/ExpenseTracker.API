
namespace ExpenseTracker.API.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public DateTime ExpenseDate { get; set; }

        public int CategoryId { get; set; } = 0;
        public string Description { get; set; }
        public Category Category { get; set; }

    }
}
