using Domain.Entities;
using AutoMapper;   
using Infrastructure.Data;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class HomeBannerService
    {
        private readonly PostgresDataContext _context;
        private readonly IMapper _mapper;

        public HomeBannerService(PostgresDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HomeBannerDto>> GetAllAsync()
        {
            var entities = await _context.HomeBanner.ToListAsync();
            return _mapper.Map<IEnumerable<HomeBannerDto>>(entities);
        }
        public async Task<HomeBannerDto> CreateOrUpdateAsync(HomeBannerDto dto)
        {
            var existingEntity = await _context.HomeBanner.FirstOrDefaultAsync();

            if (existingEntity == null)
            {
                var entity = _mapper.Map<HomeBanner>(dto);
                _context.HomeBanner.Add(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<HomeBannerDto>(entity);
            }
            else
            {
                _mapper.Map(dto, existingEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<HomeBannerDto>(existingEntity);
            }
        }
    }
}
