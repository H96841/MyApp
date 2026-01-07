using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Reposetory
{
    public class DonorRepository:IDonorRepository
    {
        private readonly AppDbContext _context; 
        public DonorRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donor>> GetAllAsync()
        {
            return await _context.Donors
            .Include(d => d.Gifts)
            .ToListAsync();
        }

        public async Task<Donor?> GetByIdAsync(int id)
        {
            return await _context.Donors
            .Include(d => d.Gifts)
            .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Donor> AddAsync(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
            return donor;
        }

        public async Task UpdateAsync(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                await _context.SaveChangesAsync();
            }
        }

    }
}
