using Domain.Entities;
using AutoMapper;   
using Infrastructure.Data;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class HomeAboutService
    {
        private readonly PostgresDataContext _context;
        private readonly IMapper _mapper;

        public HomeAboutService(PostgresDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<HomeAboutDto>> GetAllAsync()
        {
            var entities = await _context.HomeAbout.ToListAsync();

            foreach (var entity in entities)
            {
                entity.TechnologyCards = await _context.TechnologyCard.ToListAsync();
            }

            return _mapper.Map<IEnumerable<HomeAboutDto>>(entities);
        }


        public async Task<HomeAboutDto> CreateOrUpdateAsync(HomeAboutDto dto)
        {
            var existingEntity = await _context.HomeAbout.FirstOrDefaultAsync();

            if (existingEntity == null)
            {
                var entity = _mapper.Map<HomeAbout>(dto);
                _context.HomeAbout.Add(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<HomeAboutDto>(entity);
            }
            else
            {
                _mapper.Map(dto, existingEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<HomeAboutDto>(existingEntity);
            }
        }
    }
}
