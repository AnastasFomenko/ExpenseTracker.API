using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Models;

namespace ExpenseTracker.API.Interfaces
{
    public interface IExpenseService
    {
        Task<List<ExpenseDto>> GetAllAsync();

        Task<ExpenseDto> GetByIdAsync(int id);

        Task<ExpenseDto> CreateAsync(CreateExpenseDto dto);

        Task<ExpenseDto> UpdateAsync(int id, UpdateExpenseDto dto);

        Task<bool> DeleteAsync(int id);

        Task<decimal> GetTotalAsync();

        Task<decimal> GetTotalByPeriodAsync(DateTime from, DateTime to);

        Task<List<CategoryTotalDto>> GetTotalByCategoryAsync();

        Task<List<ExpenseDto>> GetByCategoryIdAsync(int categoryId);

        Task<List<ExpenseDto>> GetByPeriodAsync(DateTime from, DateTime to);

        Task<List<ExpenseDto>> GetFilteredAsync(
    int categoryId,
    DateTime from,
    DateTime to);
    }
}
