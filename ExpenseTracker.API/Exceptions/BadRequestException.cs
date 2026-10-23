namespace ExpenseTracker.API.NewFolder
{

    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
