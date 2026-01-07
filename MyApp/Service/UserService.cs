using MyApp.Dto;
using MyApp.Models;
using MyApp.Reposetory;
using MyApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<GetUserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(MapToGetUserDto);
        }

        public async Task<GetUserDto?> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user is null ? null : MapToGetUserDto(user);
        }

        public async Task CreateAsync(CreateUserDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                UserName = dto.UserName,
                Phone = dto.Phone,
                Password = dto.Password
                //,
                //Purchases = new List<Purchase>(),
                //Winner = new List<Winner>()
            };

            await _repo.AddAsync(user);
        }

        public async Task UpdateAsync(int id, UpdateUserDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var existing = await _repo.GetByIdAsync(id);
            if (existing is null)
                throw new KeyNotFoundException($"User with id {id} not found.");

            existing.Name = dto.Name ?? existing.Name;
            existing.Email = dto.Email ?? existing.Email;
            existing.UserName = dto.UserName ?? existing.UserName;
            existing.Phone = dto.Phone ?? existing.Phone;
            existing.Password = dto.Password ?? existing.Password;

            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        private static GetUserDto MapToGetUserDto(User u) =>
            new()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                UserName = u.UserName,
                Phone = u.Phone,
                Password = u.Password
            };
    }
}
