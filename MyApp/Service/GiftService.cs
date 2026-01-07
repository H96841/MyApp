using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto;
using MyApp.Models;
using MyApp.Repository;

namespace MyApp.Service
{
    public class GiftService: IGiftService
    {
        private readonly IGiftRepository _giftRepository;

        public GiftService(IGiftRepository giftRepository)
        {
            _giftRepository = giftRepository ?? throw new ArgumentNullException(nameof(giftRepository));
        }

        public async Task<IEnumerable<GetGiftDto>> GetAllAsync()
        {
            var gifts = await _giftRepository.GetAllAsync();
            return gifts.Select(MapToGetGiftDto);
        }

        public async Task<GetGiftDto?> GetByIdAsync(int id)
        {
            var gift = await _giftRepository.GetByIdAsync(id);
            return gift is null ? null : MapToGetGiftDto(gift);
        }

        public async Task<Gift> CreateAsync(CreateGiftDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var gift = new Gift
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl ?? string.Empty,
                DonorId = dto.DonorId,
                Description = dto.Description,
            };

            return await _giftRepository.AddAsync(gift);
        }

        public async Task UpdateAsync(UpdateGiftDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var existing = await _giftRepository.GetByIdAsync(dto.Id);
            if (existing is null)
                throw new KeyNotFoundException($"Gift with id {dto.Id} not found.");

            existing.Name = dto.Name;
            existing.CategoryId = dto.CategoryId;
            existing.Price = dto.Price;
            existing.ImageUrl = dto.ImageUrl ?? existing.ImageUrl;
            existing.DonorId = dto.DonorId;

            await _giftRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            await _giftRepository.DeleteAsync(id);
        }

        private static GetGiftDto MapToGetGiftDto(Gift g) =>
            new()
            {
                Id = g.Id,
                Name = g.Name,
                Price = g.Price,
                ImageUrl = g.ImageUrl
            };
    }
}
