using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Models;

namespace ExpenseTracker.API.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAllAsync();

        Task<Expense?> GetByIdAsync(int id);

         Task<Expense> CreateAsync(Expense expense);

        Task<Expense> UpdateAsync(Expense expense);

        Task<bool> DeleteAsync(int id);

        Task<decimal> GetTotalAsync();

        Task<decimal> GetTotalByPeriodAsync(DateTime from, DateTime to);

        Task<List<CategoryTotalDto>> GetTotalByCategoryAsync();

        Task<List<Expense>> GetByCategoryIdAsync(int categoryId);

        Task<List<Expense>> GetByPeriodAsync(DateTime from, DateTime to);

        Task<List<Expense>> GetFilteredAsync(
    int categoryId,
    DateTime from,
    DateTime to);
    }
}
