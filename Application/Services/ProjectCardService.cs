using Domain.Entities;
using AutoMapper;   
using Infrastructure.Data;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ProjectCardDto> CreateAsync(ProjectCardDto dto)
        {
            var entity = _mapper.Map<ProjectCard>(dto);
            _context.ProjectCard.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectCardDto>(entity);
        }

        public async Task<ProjectCardDto> UpdateAsync(int id, ProjectCardDto dto)
        {
            var existingEntity = await _context.ProjectCard.FindAsync(id);

            if (existingEntity == null)
            {
                throw new InvalidOperationException("ProjectCard not found.");
            }

            _mapper.Map(dto, existingEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectCardDto>(existingEntity);
        }

        public async Task<IEnumerable<ProjectCardDto>> GetAllAsync()
        {
            var entities = await _context.ProjectCard.ToListAsync();
            return _mapper.Map<IEnumerable<ProjectCardDto>>(entities);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ProjectCard.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            _context.ProjectCard.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
