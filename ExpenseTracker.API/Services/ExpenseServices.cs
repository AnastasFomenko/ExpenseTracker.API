using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Exceptions;
using ExpenseTracker.API.Interfaces;
using ExpenseTracker.API.Models;
using ExpenseTracker.API.NewFolder;
using ExpenseTracker.API.Repositories;

namespace ExpenseTracker.API.Services
{
    public class ExpenseServices : IExpenseService
    {       
        private readonly IExpenseRepository _expenseRepository;

        private readonly ICategoryRepository _categoryRepository;

        public ExpenseServices(IExpenseRepository expenseRepository,ICategoryRepository categoryRepository)
        {
            _expenseRepository = expenseRepository;

            _categoryRepository = categoryRepository;
        }
        public async Task<List<ExpenseDto>> GetAllAsync()
        {
            var expenses = await _expenseRepository.GetAllAsync();

            var expenseDtos = expenses.Select(expense => new ExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                ExpenseDate = expense.ExpenseDate,
                CategoryId = expense.CategoryId,
            })
                .ToList();

            return expenseDtos;
        }
        public async Task<ExpenseDto> GetByIdAsync(int id)
        {
           
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null)
            {
                throw new NotFoundException("Expense not found");
            }

            var expenseDto = new ExpenseDto
            {
                // здесь 5 свойств
                Id =  expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                ExpenseDate = expense.ExpenseDate,
                CategoryId = expense.CategoryId,
            };

            return expenseDto;
        }
        public async Task<ExpenseDto> CreateAsync(CreateExpenseDto dto)
        {
            if (dto.Amount <= 0)
            {
                throw new BadRequestException("Amount must be greater than zero");
            }

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);

            if (category == null)
            {
                throw new NotFoundException("Category not found");
            }

            var expense = new Expense
            {
                Amount = dto.Amount,
                Description = dto.Description,
                ExpenseDate = dto.ExpenseDate,
                CategoryId = dto.CategoryId
            };

            var createdExpense = await _expenseRepository.CreateAsync(expense);

            return new ExpenseDto
            {
                Id = createdExpense.Id,
                Amount = createdExpense.Amount,
                Description = createdExpense.Description,
                ExpenseDate = createdExpense.ExpenseDate,
                CategoryId = createdExpense.CategoryId
            };
        }
        public async Task<ExpenseDto> UpdateAsync(int id, UpdateExpenseDto dto)
        {
            var expenseUpdate = await _expenseRepository.GetByIdAsync(id);
            
            if (expenseUpdate == null)
            {
                throw new NotFoundException("Expense not found");
            }

            if (dto.Amount <= 0)
            {
                throw new Exception("Amount must be greater than zero");
            }

            expenseUpdate.Amount = dto.Amount;
            expenseUpdate.Description = dto.Description;
            expenseUpdate.ExpenseDate = dto.ExpenseDate;
            expenseUpdate.CategoryId = dto.CategoryId;

            var updatedExpense = await _expenseRepository.UpdateAsync(expenseUpdate);

            var expenseDto = new ExpenseDto
            {
                Id = updatedExpense.Id,
                Amount = updatedExpense.Amount,
                Description = updatedExpense.Description,
                ExpenseDate = updatedExpense.ExpenseDate,
                CategoryId = updatedExpense.CategoryId,
            };

            return expenseDto;           

        }
        public async Task<bool> DeleteAsync(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new NotFoundException("Expense not found");
            }
            await _expenseRepository.DeleteAsync(id);

            return true;
        }
        public async Task<decimal> GetTotalAsync()
        {
            var total = await _expenseRepository.GetTotalAsync();

            return total;
        }
       
        public async Task<decimal> GetTotalByPeriodAsync(DateTime from, DateTime to)
        {
            if (from > to)
            {
                throw new BadRequestException("From date cannot be later than To date");
            }
            var toExclusive = to.Date.AddDays(1);

            var total = await _expenseRepository.GetTotalByPeriodAsync(from, toExclusive);

            return total;
        }
        public async Task<List<CategoryTotalDto>> GetTotalByCategoryAsync()
        {
            var total = await _expenseRepository.GetTotalByCategoryAsync();

            return total;
        }
        public async Task<List<ExpenseDto>> GetByCategoryIdAsync(int categoryId)
        {

            var expenses = await _expenseRepository.GetByCategoryIdAsync(categoryId);

            var expenseDtos = expenses.Select(expense => new ExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                ExpenseDate = expense.ExpenseDate,
                CategoryId = expense.CategoryId,
            })
                .ToList();

            return expenseDtos;
        }
        public async Task<List<ExpenseDto>> GetByPeriodAsync(DateTime from, DateTime to)
        {
            if (from > to)
            {
                throw new BadRequestException("From date cannot be later than To date");
            }
            var toExclusive = to.Date.AddDays(1);

            var expenses = await _expenseRepository.GetByPeriodAsync(from, toExclusive);

            var expensesDto = expenses.Select(expense => new ExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                ExpenseDate = expense.ExpenseDate,
                CategoryId = expense.CategoryId,
            })
                .ToList();

            return expensesDto;
        }
        public async Task<List<ExpenseDto>> GetFilteredAsync(
   int categoryId,
   DateTime from,
   DateTime to)
        {
            if (from > to)
            {
                throw new BadRequestException("From date cannot be later than To date");
            }
            var toExclusive = to.Date.AddDays(1);

            var expenses = await _expenseRepository.GetFilteredAsync(categoryId, from, toExclusive);

            var expensesDto = expenses.Select(expense => new ExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                ExpenseDate = expense.ExpenseDate,
                CategoryId = expense.CategoryId,
            })
                .ToList();

            return expensesDto;
        }
    }
}
