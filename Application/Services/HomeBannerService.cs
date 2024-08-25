using Domain.Entities;
using AutoMapper;
using Infrastructure.Data;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

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

        public async Task<ResponseDto<IEnumerable<HomeBannerDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.HomeBanner.ToListAsync();

                if (entities == null || !entities.Any())
                {
                    throw new InvalidOperationException("No entities found.");
                }

                var homeBannerDto = _mapper.Map<IEnumerable<HomeBannerDto>>(entities);
                return new ResponseDto<IEnumerable<HomeBannerDto>>(homeBannerDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto<IEnumerable<HomeBannerDto>>($"An error occurred while retrieving data: {ex.Message}");
            }
        }

        public async Task<ResponseDto<HomeBannerDto>> CreateOrUpdateAsync(HomeBannerDto dto)
        {
            try
            {
                var existingEntity = await _context.HomeBanner.FirstOrDefaultAsync();

                if (existingEntity == null)
                {
                    var newEntity = _mapper.Map<HomeBanner>(dto);
                    _context.HomeBanner.Add(newEntity);
                    await _context.SaveChangesAsync();
                    return new ResponseDto<HomeBannerDto>(_mapper.Map<HomeBannerDto>(newEntity));
                }
                else
                {
                    var existingId = existingEntity.Id;
                    _mapper.Map(dto, existingEntity);
                    existingEntity.Id = existingId;
                    await _context.SaveChangesAsync();
                    return new ResponseDto<HomeBannerDto>(_mapper.Map<HomeBannerDto>(existingEntity));
                }
            }
            catch (InvalidOperationException ex)
            {
                return new ResponseDto<HomeBannerDto>($"Operation failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ResponseDto<HomeBannerDto>($"An error occurred: {ex.Message}");
            }
        }
    }
}
