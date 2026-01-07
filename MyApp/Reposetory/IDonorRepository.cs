using MyApp.Models;

namespace MyApp.Reposetory
{
    // Change from class to interface, and remove method body
    public interface IDonorRepository
    {
        Task<IEnumerable<Donor>> GetAllAsync();
        Task<Donor?> GetByIdAsync(int id);
        Task<Donor>AddAsync(Donor donor);
        Task UpdateAsync(Donor donor);
        Task DeleteAsync(int id);

    }
}
