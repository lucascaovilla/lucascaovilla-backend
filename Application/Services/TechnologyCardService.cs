using Domain.Entities;
using AutoMapper;   
using Infrastructure.Data;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TechnologyCardService
    {
        private readonly PostgresDataContext _context;
        private readonly IMapper _mapper;

        public TechnologyCardService(PostgresDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TechnologyCardDto> CreateAsync(TechnologyCardDto dto)
        {
            var entity = _mapper.Map<TechnologyCard>(dto);
            _context.TechnologyCard.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TechnologyCardDto>(entity);
        }

        public async Task<TechnologyCardDto> UpdateAsync(int id, TechnologyCardDto dto)
        {
            var existingEntity = await _context.TechnologyCard.FindAsync(id);

            if (existingEntity == null)
            {
                throw new InvalidOperationException("TechnologyCard not found.");
            }

            _mapper.Map(dto, existingEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TechnologyCardDto>(existingEntity);
        }

        public async Task<IEnumerable<TechnologyCardDto>> GetAllAsync()
        {
            var entities = await _context.TechnologyCard.ToListAsync();
            return _mapper.Map<IEnumerable<TechnologyCardDto>>(entities);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.TechnologyCard.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            _context.TechnologyCard.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
