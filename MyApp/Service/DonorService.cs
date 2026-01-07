using MyApp.Dto;
using MyApp.Models;
using MyApp.Reposetory;

namespace MyApp.Service
{
    public class DonorService : IDonorService
    {

        private readonly IDonorRepository _DonorRepository;
      

        public DonorService(IDonorRepository donorRepository)
        {
            _DonorRepository = donorRepository ?? throw new ArgumentNullException(nameof(donorRepository));

        }

        public async Task<IEnumerable<GetDonorDto>> GetAllAsync()
        {
            var donors = await _DonorRepository.GetAllAsync();
            return donors.Select(MapToGetDonorDto);
            
        }

        public async Task<GetDonorDto?> GetByIdAsync(int id)
        {
            var donor = await _DonorRepository.GetByIdAsync(id);
            return donor is null ? null : MapToGetDonorDto(donor);
        }



        public async Task<Donor> CreateAsync(CreateDonorDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            
            var donor = new Donor
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            return await _DonorRepository.AddAsync(donor);

        }



        public async Task UpdateAsync(UpdateDonorDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var exsisting = await _DonorRepository.GetByIdAsync(dto.Id);
            if (exsisting is null)
                throw new KeyNotFoundException($"Donor with id {dto.Id} not found.");

            exsisting.Name = dto.Name;
            exsisting.Email = dto.Email;
            exsisting.Phone = dto.Phone;

            await _DonorRepository.UpdateAsync(exsisting);
        }



        public async Task DeleteAsync(int id)
        {
            await _DonorRepository.DeleteAsync(id);
        }

        private static GetDonorDto MapToGetDonorDto(Donor d)=>
             new()
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.Email,
                Phone = d.Phone
            };
        }
    }
