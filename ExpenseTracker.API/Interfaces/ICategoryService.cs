using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Models;

namespace ExpenseTracker.API.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();

        Task<CategoryDto> GetByIdAsync(int id);

        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);

        Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
