namespace Application.DTOs
{
    public class HomePortfolioDto
    {
        public int Id { get; set; }
        public required string BackgroundImageAlt { get; set; }
        public required int BackgroundImageWidth { get; set; }
        public required int BackgroundImageHeight { get; set; }
        public required string BackgroundImageSrc { get; set; }
        public string? BackgroundImageAvifSrc { get; set; }
        public string? BackgroundImageWebpSrc { get; set; }
        public string? BackgroundImageJpgSrc { get; set; }
        public List<ProjectCardDto> ProjectCards { get; set; } = [];

    }
}
