namespace Application.DTOs
{
    public class HomeBannerDto
    {
        public int Id { get; }
        public required string BackgroundImageAlt { get; set; }
        public required int BackgroundImageWidth { get; set; }
        public required int BackgroundImageHeight { get; set; }
        public required string BackgroundImageSrc { get; set; }
        public string? BackgroundImageAvifSrc { get; set; }
        public string? BackgroundImageWebpSrc { get; set; }
        public string? BackgroundImageJpgSrc { get; set; }

    }
}
