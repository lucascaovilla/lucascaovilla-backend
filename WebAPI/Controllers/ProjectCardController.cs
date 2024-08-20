using Application.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/project-card")]
    [ApiController]
    public class ProjectCardController : ControllerBase
    {
        private readonly ProjectCardService _service;

        public ProjectCardController(ProjectCardService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCardDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdDto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = createdDto.Id }, createdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProjectCardDto dto)
        {
            if (dto == null)
            {
                return BadRequest("ID mismatch or invalid data.");
            }
            
            int id = dto.Id;

            try
            {
                var updatedDto = await _service.UpdateAsync(id, dto);
                return Ok(updatedDto);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody] DeleteDto dto)
        {
            var deleted = await _service.DeleteAsync(dto.Id);

            if (!deleted)
            {
                return NotFound(new { message = "ProjectCard not found." });
            }

            return NoContent();
        }
    }
}
