using Application.DTOs;
using Infrastructure.Data;
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

        public async Task<HomeDto> GetAllAsync()
        {
            var homeBanner = (await _homeBannerService.GetAllAsync()).FirstOrDefault();
            var homeAbout = (await _homeAboutService.GetAllAsync()).FirstOrDefault();
            var homePortfolio = (await _homePortfolioService.GetAllAsync()).FirstOrDefault();


            return new HomeDto
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
        }
    }
}
