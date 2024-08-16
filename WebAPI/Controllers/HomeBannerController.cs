using Application.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/homebanner")]
    [ApiController]
    public class HomeBannerController : ControllerBase
    {
        private readonly HomeBannerService _service;

        public HomeBannerController(HomeBannerService service)
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
        public async Task<IActionResult> Create([FromBody] HomeBannerDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdDto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = createdDto.Id }, createdDto);
        }
    }
}
