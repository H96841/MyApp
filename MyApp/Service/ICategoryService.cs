using MyApp.Dto;
using MyApp.Models;

namespace MyApp.Service
{
    public interface ICategoryService
    {


        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto?> GetByIdAsync(int id);
        Task<Category> CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(UpdateCategoryDto dto);
        Task DeleteAsync(int id);


    }
}
