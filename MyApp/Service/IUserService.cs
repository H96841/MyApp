using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Dto;

namespace MyApp.Service
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetAllAsync();
        Task<GetUserDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateUserDto dto);
        Task UpdateAsync(int id, UpdateUserDto dto);
        Task DeleteAsync(int id);
    }
}
