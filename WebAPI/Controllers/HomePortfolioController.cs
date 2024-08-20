using Application.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/home-portfolio")]
    [ApiController]
    public class HomePortfolioController : ControllerBase
    {
        private readonly HomePortfolioService _service;

        public HomePortfolioController(HomePortfolioService service)
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] HomePortfolioDto dto)
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
