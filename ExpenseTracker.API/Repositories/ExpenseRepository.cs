using ExpenseTracker.API.Data;
using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Interfaces;
using ExpenseTracker.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExpenseTracker.API.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExpenseRepository(AppDbContext context)
        {
            this._appDbContext = context;
        }

        public async Task<List<Expense>> GetAllAsync()
        {
            return await _appDbContext.Expenses.ToListAsync();
        }
        public async Task<Expense?> GetByIdAsync(int id)
        {
            return await _appDbContext.Expenses
    .FirstOrDefaultAsync(expense =>
        expense.Id == id);
        
        }
        public async Task<Expense> CreateAsync(Expense expense)
        {
            _appDbContext.Expenses.Add(expense);
            await _appDbContext.SaveChangesAsync();

            return expense;
        }
        public async Task<Expense> UpdateAsync(Expense expense)
        {
            _appDbContext.Expenses.Update(expense);
            await _appDbContext.SaveChangesAsync();

            return expense;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var expense = await GetByIdAsync(id);

            if (expense == null)
            {
                return false;
            }
            _appDbContext.Expenses.Remove(expense);


            await _appDbContext.SaveChangesAsync();

            return true;
        }      

          public async Task<decimal> GetTotalAsync()
        {
            return await _appDbContext.Expenses
                .SumAsync(expense => expense.Amount);
        }
        public async Task<decimal> GetTotalByPeriodAsync(DateTime from, DateTime to)
        {
            return await _appDbContext.Expenses
               .Where(expense =>
    expense.ExpenseDate >= from &&
    expense.ExpenseDate < to)
               .SumAsync(expense => expense.Amount);
        }
        public async Task<List<CategoryTotalDto>> GetTotalByCategoryAsync()
        {
            return await _appDbContext.Expenses
     .GroupBy(expense => expense.CategoryId)
     .Select(group => new CategoryTotalDto
     {
         Category = group.First().Category.Name,
         Total = group.Sum(expense => expense.Amount)
     })
     .ToListAsync();
        }
        public async Task<List<Expense>> GetByCategoryIdAsync(int categoryId)
        {
            return await _appDbContext.Expenses
                .Where(expense => expense.CategoryId == categoryId)
                .ToListAsync();
        }
        public async Task<List<Expense>> GetByPeriodAsync(DateTime from, DateTime to)
        {
            return await _appDbContext.Expenses
               .Where(expense =>
    expense.ExpenseDate >= from &&
    expense.ExpenseDate < to)
               .ToListAsync();
        }
        public async Task<List<Expense>> GetFilteredAsync(
    int categoryId,
    DateTime from,
    DateTime to)
        {
            return await _appDbContext.Expenses
                .Where(expense => expense.CategoryId == categoryId && 
    expense.ExpenseDate >= from &&
    expense.ExpenseDate < to)
                               
                .ToListAsync();
        }
    }

  }


// Repository → работа с данными
//Service    → бизнес-логика
//Controller → HTTP/API 
