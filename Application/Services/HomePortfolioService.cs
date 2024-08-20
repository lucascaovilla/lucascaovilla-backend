using Domain.Entities;
using AutoMapper;   
using Infrastructure.Data;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class HomePortfolioService
    {
        private readonly PostgresDataContext _context;
        private readonly IMapper _mapper;

        public HomePortfolioService(PostgresDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<HomePortfolioDto>> GetAllAsync()
        {
            var entities = await _context.HomePortfolio.ToListAsync();

            foreach (var entity in entities)
            {
                entity.ProjectCards = await _context.ProjectCard.ToListAsync();
            }

            return _mapper.Map<IEnumerable<HomePortfolioDto>>(entities);
        }


        public async Task<HomePortfolioDto> CreateOrUpdateAsync(HomePortfolioDto dto)
        {
            var existingEntity = await _context.HomePortfolio.FirstOrDefaultAsync();

            if (existingEntity == null)
            {
                var entity = _mapper.Map<HomePortfolio>(dto);
                _context.HomePortfolio.Add(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<HomePortfolioDto>(entity);
            }
            else
            {
                _mapper.Map(dto, existingEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<HomePortfolioDto>(existingEntity);
            }
        }
    }
}
