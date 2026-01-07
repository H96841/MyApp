using MyApp.Dto;
using MyApp.Models;

namespace MyApp.Service
{
    public interface IDonorService
    {

        Task<IEnumerable<GetDonorDto>> GetAllAsync();
        Task<GetDonorDto?> GetByIdAsync(int id);
        Task <Donor>CreateAsync(CreateDonorDto dto);
        Task UpdateAsync(UpdateDonorDto dto);
        Task DeleteAsync(int id);
    }
}
