using Application.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/technology-card")]
    [ApiController]
    public class TechnologyCardController : ControllerBase
    {
        private readonly TechnologyCardService _service;

        public TechnologyCardController(TechnologyCardService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAllAsync();

            if (!response.Success)
            {
                return BadRequest(new { message = response.Message });
            }

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TechnologyCardDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            var response = await _service.CreateAsync(dto);

            if (!response.Success)
            {
                return BadRequest(new { message = response.Message });
            }

            return CreatedAtAction(nameof(GetAll), new { id = response.Data.Id }, response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TechnologyCardDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            int id = dto.Id;

            try
            {
                var updatedDto = await _service.UpdateAsync(id, dto);

                if (updatedDto == null)
                {
                    return NotFound(new { message = "Update failed or item not found." });
                }

                return Ok(updatedDto);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteDto dto)
        {
            if (dto == null || dto.Id <= 0)
            {
                return BadRequest("Invalid data.");
            }

            var response = await _service.DeleteAsync(dto.Id);

            if (!response.Success)
            {
                return NotFound(new { message = response.Message });
            }

            return NoContent();
        }
    }
}
