using Application.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var response = await _service.GetAllAsync();

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] HomePortfolioDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new ResponseDto<HomePortfolioDto>("Invalid data."));
            }

            var response = await _service.CreateOrUpdateAsync(dto);

            if (response.Success)
            {
                return CreatedAtAction(nameof(GetAll), new { id = response.Data?.Id }, response);
            }
            else
            {
                return Conflict(response);
            }
        }
    }
}
