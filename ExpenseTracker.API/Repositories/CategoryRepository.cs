using ExpenseTracker.API.Data;
using ExpenseTracker.API.Interfaces;
using ExpenseTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext context)
        {
            this._appDbContext = context;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _appDbContext.Categories.ToListAsync();
        }
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _appDbContext.Categories
    .FirstOrDefaultAsync(category =>
        category.Id == id);

        }
        public async Task<Category> CreateAsync(Category category)
        {
            _appDbContext.Categories.Add(category);
            await _appDbContext.SaveChangesAsync();

            return category;
        }
        public async Task<Category> UpdateAsync(Category category)
        {
            _appDbContext.Categories.Update(category);
            await _appDbContext.SaveChangesAsync();

            return category;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);

            if (category == null)
            {
                return false;
            }

            _appDbContext.Categories.Remove(category);

            await _appDbContext.SaveChangesAsync();

            return true;

        }
    }
}
