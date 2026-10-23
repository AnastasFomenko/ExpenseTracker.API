namespace ExpenseTracker.API.DTOs
{
    public class UpdateExpenseDto
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public DateTime ExpenseDate { get; set; }
        public int CategoryId { get; set; }
    }
}
