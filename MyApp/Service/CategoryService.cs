using MyApp.Dto;
using MyApp.Models;
using MyApp.Reposetory;

namespace MyApp.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly ICateroryRepository _CateroryRepository;

        public CategoryService(ICateroryRepository CateroryRepository)
        {
            _CateroryRepository = CateroryRepository ?? throw new ArgumentNullException(nameof(CategoryService));
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
             var categories = await _CateroryRepository.GetAllAsync(); 
            return categories.Select(MapToGetCategoryDto);

        }


        public async Task<GetCategoryDto?> GetByIdAsync(int id)
        {
            var categories= await _CateroryRepository.GetByIdAsync(id);
            return categories is null?null: MapToGetCategoryDto(categories);
        }

        public async Task<Category> CreateAsync(CreateCategoryDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
         
            var category = new Category
            {
                Name = dto.Name
            };

            return await _CateroryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var existing = await _CateroryRepository.GetByIdAsync(dto.Id);
            if (existing is null)
                throw new KeyNotFoundException($"Category with id {dto.Id} not found.");

            existing.Name = dto.Name;
            await _CateroryRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _CateroryRepository.DeleteAsync(id);
        }

        private static GetCategoryDto MapToGetCategoryDto(Category c)=>
          new()
          {
              Id =  c.Id,
              Name = c.Name
          };

        

    }
}
