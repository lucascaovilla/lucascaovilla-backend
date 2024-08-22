namespace Application.DTOs
{
    public class HomeDto
    {
        public required HomeBannerDto? HomeBanner { get; set; }
        public required HomeAboutDto? HomeAbout { get; set; }
        public required HomePortfolioDto? HomePortfolio { get; set; }

    }
}
