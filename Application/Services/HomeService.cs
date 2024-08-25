using Application.DTOs;
using AutoMapper;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HomeService
    {
        private readonly HomeBannerService _homeBannerService;
        private readonly HomeAboutService _homeAboutService;
        private readonly HomePortfolioService _homePortfolioService;
        private readonly IMapper _mapper;

        public HomeService(HomeBannerService homeBannerService, HomeAboutService homeAboutService, HomePortfolioService homePortfolioService, IMapper mapper)
        {
            _homeBannerService = homeBannerService;
            _homeAboutService = homeAboutService;
            _homePortfolioService = homePortfolioService;
            _mapper = mapper;
        }

        public async Task<ResponseDto<HomeDto>> GetAllAsync()
        {
            try
            {
                var homeBannerResponse = await _homeBannerService.GetAllAsync();
                var homeAboutResponse = await _homeAboutService.GetAllAsync();
                var homePortfolioResponse = await _homePortfolioService.GetAllAsync();

                var homeBanner = homeBannerResponse.Data?.FirstOrDefault();
                var homeAbout = homeAboutResponse.Data?.FirstOrDefault();
                var homePortfolio = homePortfolioResponse.Data?.FirstOrDefault();

                var homeDto = new HomeDto
                {
                    HomeBanner = homeBanner ?? new HomeBannerDto
                    {
                        BackgroundImageAlt = "Default",
                        BackgroundImageWidth = 100,
                        BackgroundImageHeight = 100,
                        BackgroundImageSrc = "default"
                    },
                    HomeAbout = homeAbout ?? new HomeAboutDto
                    {
                        Description = "",
                        Caption = ""
                    },
                    HomePortfolio = homePortfolio ?? new HomePortfolioDto
                    {
                        BackgroundImageAlt = "Default",
                        BackgroundImageWidth = 100,
                        BackgroundImageHeight = 100,
                        BackgroundImageSrc = "default"
                    }
                };

                return new ResponseDto<HomeDto>(homeDto);
            }
            catch (Exception ex)
            {
                return new ResponseDto<HomeDto>(message: $"An error occurred while retrieving home data: {ex.Message}");
            }
        }
    }
}
