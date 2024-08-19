using Application.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/home-about")]
    [ApiController]
    public class HomeAboutController : ControllerBase
    {
        private readonly HomeAboutService _service;

        public HomeAboutController(HomeAboutService service)
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] HomeAboutDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var createdOrUpdatedDto = await _service.CreateOrUpdateAsync(dto);
                return CreatedAtAction(nameof(GetAll), new { id = createdOrUpdatedDto.Id }, createdOrUpdatedDto);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
    }
}
