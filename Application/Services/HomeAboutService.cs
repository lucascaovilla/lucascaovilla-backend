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
    public class HomeAboutService
    {
        private readonly PostgresDataContext _context;
        private readonly IMapper _mapper;

        public HomeAboutService(PostgresDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<HomeAboutDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.HomeAbout.ToListAsync();

                if (entities == null || !entities.Any())
                {
                    throw new InvalidOperationException("No entities found.");
                }
                foreach (var entity in entities)
                {
                    entity.TechnologyCards = await _context.TechnologyCard.ToListAsync();
                }
                var homeAboutDto = _mapper.Map<IEnumerable<HomeAboutDto>>(entities);
                return new ResponseDto<IEnumerable<HomeAboutDto>>(homeAboutDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto<IEnumerable<HomeAboutDto>>($"An error occurred while retrieving data: {ex.Message}");
            }
        }

        public async Task<ResponseDto<HomeAboutDto>> CreateOrUpdateAsync(HomeAboutDto dto)
        {
            try
            {
                var existingEntity = await _context.HomeAbout.FirstOrDefaultAsync();

                if (existingEntity == null)
                {
                    var entity = _mapper.Map<HomeAbout>(dto);
                    entity.TechnologyCards = await _context.TechnologyCard.ToListAsync();
                    _context.HomeAbout.Add(entity);
                    await _context.SaveChangesAsync();
                    return new ResponseDto<HomeAboutDto>(_mapper.Map<HomeAboutDto>(entity));
                }
                else
                {
                    var existingId = existingEntity.Id;
                    _mapper.Map(dto, existingEntity);
                    existingEntity.Id = existingId;
                    await _context.SaveChangesAsync();
                    existingEntity.TechnologyCards = await _context.TechnologyCard.ToListAsync();
                    return new ResponseDto<HomeAboutDto>(_mapper.Map<HomeAboutDto>(existingEntity));
                }
            }
            catch (InvalidOperationException ex)
            {
                return new ResponseDto<HomeAboutDto>($"Operation failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ResponseDto<HomeAboutDto>($"An error occurred: {ex.Message}");
            }
        }
    }
}
