using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET ALL будет здесь
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var expenses = await _expenseService.GetAllAsync();

            return Ok(expenses);
            // верни Ok(...)
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var expense = await _expenseService.GetByIdAsync(id);

           return Ok(expense);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseDto dto)
        {
           var expense = await _expenseService.CreateAsync(dto);

            return Ok(expense);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateExpenseDto dto)
        {
            var expenses = await _expenseService.UpdateAsync(id, dto);
            
            return Ok(expenses);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expenseService.DeleteAsync(id);

            return Ok(expense);
        }
        [HttpGet("total")]
        public async Task<IActionResult> GetTotal()
        {
            var total = await _expenseService.GetTotalAsync();

            return Ok(total);
        }
        [HttpGet("total/period")]
        public async Task<IActionResult> GetTotalByPeriod(DateTime from, DateTime to)
        {
            var total = await _expenseService.GetTotalByPeriodAsync(from, to);

            return Ok(total);
        }
        [HttpGet("total/category")]
        public async Task<IActionResult> GetTotalByCategoryAsync()
        {
            var total = await _expenseService.GetTotalByCategoryAsync();

            return Ok(total);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var expenses = await _expenseService.GetByCategoryIdAsync(categoryId);

            return Ok(expenses);
        }
        [HttpGet("period")]
        public async Task<IActionResult> GetByPeriod(DateTime from, DateTime to)
        {
            var period = await _expenseService.GetByPeriodAsync(from, to);

            return Ok(period);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered(int categoryId, DateTime from, DateTime to)
        {
            var categoryPeriod = await _expenseService.GetFilteredAsync(categoryId, from, to);

            return Ok(categoryPeriod);
        }
       }
    }

