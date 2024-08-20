namespace Application.DTOs
{
    public class HomePortfolioDto
    {
        public int Id { get; set; }
        public required string BackgroundImageSrc { get; set; }
        public List<ProjectCardDto> ProjectCards { get; set; } = [];

    }
}
