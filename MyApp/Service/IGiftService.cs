using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Dto;
using MyApp.Models;

namespace MyApp.Service
{
    public interface IGiftService
    {
        Task<IEnumerable<GetGiftDto>> GetAllAsync();
        Task<GetGiftDto?> GetByIdAsync(int id);
        Task<Gift> CreateAsync(CreateGiftDto dto);
        Task UpdateAsync(UpdateGiftDto dto);
        Task DeleteAsync(int id);
    }
}