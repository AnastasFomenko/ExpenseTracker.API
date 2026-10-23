using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Exceptions;
using ExpenseTracker.API.Interfaces;
using ExpenseTracker.API.Models;
using ExpenseTracker.API.Repositories;

namespace ExpenseTracker.API.Services
{
    public class CategoryServices : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesDto = categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            })
                .ToList();

            return categoriesDto;
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
         var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                throw new NotFoundException("Category not found");
            }
            var categoryDto = new CategoryDto
            {
                Name = category.Name,
                Id = category.Id,
            };
            return categoryDto;
        }
        
           public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new Exception("Category name is required");
            }

            var category = new Category
            {
                Name = dto.Name
            };

            var createdCategory = await _categoryRepository.CreateAsync(category);

            var categoryDto = new CategoryDto
            {
                Id = createdCategory.Id,
                Name = createdCategory.Name
            };

            return categoryDto;
        }
        public async Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var categoryUpdate = await _categoryRepository.GetByIdAsync(id);

            if (categoryUpdate == null)
            {
                throw new NotFoundException("Category not found");
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new Exception("Category name is required");
            }
            categoryUpdate.Name = dto.Name;

            var updatedCategory = await _categoryRepository.UpdateAsync(categoryUpdate);

            var categoryDto = new CategoryDto
            {
                Id = updatedCategory.Id,
                Name = updatedCategory.Name
            };

            return categoryDto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                throw new NotFoundException("Category not found");
            }
            await _categoryRepository.DeleteAsync(id);

            return true;
        }

    }

}
