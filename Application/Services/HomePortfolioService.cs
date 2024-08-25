using Domain.Entities;
using AutoMapper;
using Infrastructure.Data;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        public async Task<ResponseDto<IEnumerable<HomePortfolioDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.HomePortfolio.ToListAsync();

                if (entities == null || !entities.Any())
                {
                    throw new InvalidOperationException("No entities found.");
                }
                foreach (var entity in entities)
                {
                    entity.ProjectCards = await _context.ProjectCard.ToListAsync();
                }
                var homePortfolioDto = _mapper.Map<IEnumerable<HomePortfolioDto>>(entities);
                return new ResponseDto<IEnumerable<HomePortfolioDto>>(homePortfolioDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto<IEnumerable<HomePortfolioDto>>($"An error occurred while retrieving data: {ex.Message}");
            }
        }

        public async Task<ResponseDto<HomePortfolioDto>> CreateOrUpdateAsync(HomePortfolioDto dto)
        {
            try
            {
                var existingEntity = await _context.HomePortfolio.FirstOrDefaultAsync();

                if (existingEntity == null)
                {
                    var entity = _mapper.Map<HomePortfolio>(dto);
                    entity.ProjectCards = await _context.ProjectCard.ToListAsync();
                    _context.HomePortfolio.Add(entity);
                    await _context.SaveChangesAsync();
                    return new ResponseDto<HomePortfolioDto>(_mapper.Map<HomePortfolioDto>(entity));
                }
                else
                {
                    var existingId = existingEntity.Id;
                    _mapper.Map(dto, existingEntity);
                    existingEntity.Id = existingId;
                    await _context.SaveChangesAsync();
                    existingEntity.ProjectCards = await _context.ProjectCard.ToListAsync();
                    return new ResponseDto<HomePortfolioDto>(_mapper.Map<HomePortfolioDto>(existingEntity));
                }
            }
            catch (InvalidOperationException ex)
            {
                return new ResponseDto<HomePortfolioDto>($"Operation failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ResponseDto<HomePortfolioDto>($"An error occurred: {ex.Message}");
            }
        }
    }
}
