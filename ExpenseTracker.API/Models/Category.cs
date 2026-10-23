namespace ExpenseTracker.API.Models
{
    public class Category
    {
       public int Id { get; set; }

        public string Name { get; set; }

        // Category
        public List<Expense> Expenses { get; set; } = new();

    }
}
