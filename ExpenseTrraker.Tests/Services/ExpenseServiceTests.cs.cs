using Xunit;
using Moq;
using ExpenseTracker.API.Interfaces;
using ExpenseTracker.API.Services;
using ExpenseTracker.API.Exceptions;
using ExpenseTracker.API.NewFolder;
using ExpenseTracker.API.Models;
using ExpenseTracker.API.DTOs;

namespace ExpenseTracker.Tests.Services
{
    public class ExpenseServiceTests
    {
        private readonly Mock<IExpenseRepository> _repositoryMock;
        private readonly ExpenseServices _service;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;


        public ExpenseServiceTests()
        {
            _repositoryMock = new Mock<IExpenseRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();

            _service = new ExpenseServices(
                _repositoryMock.Object,
                _categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task GetByPeriodAsync_ShouldThrowBadRequestException_WhenFromIsLaterThanTo()
        {
            DateTime from = new DateTime(2026, 10, 30);
            DateTime to = new DateTime(2026, 10, 1);

            // Здесь напишем проверку
            await Assert.ThrowsAsync<BadRequestException>(
      async () => await _service.GetByPeriodAsync(from, to)
  );
        }
        [Fact]
        public async Task GetByPeriodAsync_ShouldReturnTwoExpenses_WhenDatesAreValid()
        {
            // Здесь будет тест
            DateTime from = new DateTime(2026, 10, 1);
            DateTime to = new DateTime(2026, 10, 30);

            var expenses = new List<Expense>
{
    new Expense
    {
        Id = 1,
        Amount = 250,
        Description = "Food",
        ExpenseDate = new DateTime(2026, 10, 10),
        CategoryId = 1
    },
    new Expense
    {
        Id = 2,
        Amount = 100,
        Description = "Transport",
        ExpenseDate = new DateTime(2026, 10, 11),
        CategoryId = 2
    }
};

            _repositoryMock
    .Setup(repo => repo.GetByPeriodAsync(
        It.IsAny<DateTime>(),
        It.IsAny<DateTime>()))
    .ReturnsAsync(expenses);

            var result = await _service.GetByPeriodAsync(from, to);

            // Проверяем количество расходов
            Assert.Equal(2, result.Count);

            // Проверяем сумму первого расхода
            Assert.Equal(250m, result[0].Amount);

            Assert.Equal(100, result[1].Amount);

        }
        [Fact]
        public async Task GetByPeriodAsync_ShouldReturnEmptyList_WhenNoExpensesFound()
        {
            // Arrange
            DateTime from = new DateTime(2026, 10, 1);
            DateTime to = new DateTime(2026, 10, 30);

            _repositoryMock
                .Setup(repo => repo.GetByPeriodAsync(
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(new List<Expense>());

            // Act
            var result = await _service.GetByPeriodAsync(from, to);

            // Assert
            Assert.Empty(result);
        }
        [Fact]
        public async Task CreateAsync_ShouldThrowNotFoundException_WhenCategoryDoesNotExist()
        {
            var dto = new CreateExpenseDto
            {
                Amount = 250,
                Description = "Lunch",
                ExpenseDate = new DateTime(2026, 10, 23),
                CategoryId = 999
            };

            _categoryRepositoryMock
    .Setup(repo => repo.GetByIdAsync(999))
    .ReturnsAsync((Category?)null);

            await Assert.ThrowsAsync<NotFoundException>(
    async () => await _service.CreateAsync(dto)
);

            _repositoryMock.Verify(
    repo => repo.CreateAsync(It.IsAny<Expense>()),
    Times.Never);
            // Assert
        }
    }
}