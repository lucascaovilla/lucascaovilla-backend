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
    public class TechnologyCardService
    {
        private readonly PostgresDataContext _context;
        private readonly IMapper _mapper;

        public TechnologyCardService(PostgresDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<TechnologyCardDto>> CreateAsync(TechnologyCardDto dto)
        {
            try
            {
                var entity = _mapper.Map<TechnologyCard>(dto);
                _context.TechnologyCard.Add(entity);
                await _context.SaveChangesAsync();
                var resultDto = _mapper.Map<TechnologyCardDto>(entity);
                return new ResponseDto<TechnologyCardDto>(resultDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto<TechnologyCardDto>(message: $"An error occurred while creating the technology card: {ex.Message}");
            }
        }

        public async Task<ResponseDto<TechnologyCardDto>> UpdateAsync(int id, TechnologyCardDto dto)
        {
            try
            {
                var existingEntity = await _context.TechnologyCard.FindAsync(id);

                if (existingEntity == null)
                {
                    return new ResponseDto<TechnologyCardDto>(message: "TechnologyCard not found.");
                }

                _mapper.Map(dto, existingEntity);
                await _context.SaveChangesAsync();
                var resultDto = _mapper.Map<TechnologyCardDto>(existingEntity);
                return new ResponseDto<TechnologyCardDto>(resultDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto<TechnologyCardDto>(message: $"An error occurred while updating the technology card: {ex.Message}");
            }
        }

        public async Task<ResponseDto<IEnumerable<TechnologyCardDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.TechnologyCard.ToListAsync();
                var resultDtos = _mapper.Map<IEnumerable<TechnologyCardDto>>(entities);
                return new ResponseDto<IEnumerable<TechnologyCardDto>>(resultDtos);
            }
            catch (Exception ex)
            {
                return new ResponseDto<IEnumerable<TechnologyCardDto>>(message: $"An error occurred while retrieving technology cards: {ex.Message}");
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.TechnologyCard.FindAsync(id);

                if (entity == null)
                {
                    return new ResponseDto<bool>(message: "TechnologyCard not found.");
                }

                _context.TechnologyCard.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseDto<bool>(true);
            }
            catch (Exception ex)
            {
                return new ResponseDto<bool>(message: $"An error occurred while deleting the technology card: {ex.Message}");
            }
        }
    }
}
