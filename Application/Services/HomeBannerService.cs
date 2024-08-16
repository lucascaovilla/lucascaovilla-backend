using Domain.Entities;
using Infrastructure.Data;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class HomeBannerService
    {
        private readonly PostgresDataContext _context;

        public HomeBannerService(PostgresDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HomeBannerDto>> GetAllAsync()
        {
            return await _context.HomeBanner
                                .Select(e => new HomeBannerDto {
                                    Id = e.Id,
                                    BackgroundImageAvifSrc = e.BackgroundImageAvifSrc,
                                    BackgroundImageWebpSrc = e.BackgroundImageWebpSrc,
                                    BackgroundImageSrc = e.BackgroundImageSrc,
                                    BackgroundImageAlt = e.BackgroundImageAlt,
                                    BackgroundImageWidth = e.BackgroundImageWidth,
                                    BackgroundImageHeight = e.BackgroundImageHeight,
                                }).ToListAsync();
        }

        public async Task<HomeBannerDto> CreateAsync(HomeBannerDto dto)
        {
            var entity = new HomeBanner
            {
                BackgroundImageAvifSrc = dto.BackgroundImageAvifSrc,
                BackgroundImageWebpSrc = dto.BackgroundImageWebpSrc,
                BackgroundImageSrc = dto.BackgroundImageSrc,
                BackgroundImageAlt = dto.BackgroundImageAlt,
                BackgroundImageWidth = dto.BackgroundImageWidth,
                BackgroundImageHeight = dto.BackgroundImageHeight,
            };

            _context.HomeBanner.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }
    }
}
