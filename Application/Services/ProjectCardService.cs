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
    public class ProjectCardService
    {
        private readonly PostgresDataContext _context;
        private readonly IMapper _mapper;

        public ProjectCardService(PostgresDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectCardDto>> CreateAsync(ProjectCardDto dto)
        {
            try
            {
                var entity = _mapper.Map<ProjectCard>(dto);
                _context.ProjectCard.Add(entity);
                await _context.SaveChangesAsync();
                var resultDto = _mapper.Map<ProjectCardDto>(entity);
                return new ResponseDto<ProjectCardDto>(resultDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto<ProjectCardDto>(message: $"An error occurred while creating the project card: {ex.Message}");
            }
        }

        public async Task<ResponseDto<ProjectCardDto>> UpdateAsync(int id, ProjectCardDto dto)
        {
            try
            {
                var existingEntity = await _context.ProjectCard.FindAsync(id);

                if (existingEntity == null)
                {
                    return new ResponseDto<ProjectCardDto>(message: "ProjectCard not found.");
                }

                _mapper.Map(dto, existingEntity);
                await _context.SaveChangesAsync();
                var resultDto = _mapper.Map<ProjectCardDto>(existingEntity);
                return new ResponseDto<ProjectCardDto>(resultDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto<ProjectCardDto>(message: $"An error occurred while updating the project card: {ex.Message}");
            }
        }

        public async Task<ResponseDto<IEnumerable<ProjectCardDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _context.ProjectCard.ToListAsync();
                var resultDtos = _mapper.Map<IEnumerable<ProjectCardDto>>(entities);
                return new ResponseDto<IEnumerable<ProjectCardDto>>(resultDtos);
            }
            catch (Exception ex)
            {
                return new ResponseDto<IEnumerable<ProjectCardDto>>(message: $"An error occurred while retrieving project cards: {ex.Message}");
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.ProjectCard.FindAsync(id);

                if (entity == null)
                {
                    return new ResponseDto<bool>(message: "ProjectCard not found.");
                }

                _context.ProjectCard.Remove(entity);
                await _context.SaveChangesAsync();
                return new ResponseDto<bool>(true);
            }
            catch (Exception ex)
            {
                return new ResponseDto<bool>(message: $"An error occurred while deleting the project card: {ex.Message}");
            }
        }
    }
}
