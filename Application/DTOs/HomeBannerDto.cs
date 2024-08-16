namespace Application.DTOs
{
    public class HomeBannerDto
    {
        public int Id { get; set; }
        public required string BackgroundImageAvifSrc { get; set; }
        public required string BackgroundImageWebpSrc { get; set; }
        public required string BackgroundImageSrc { get; set; }
        public required string BackgroundImageAlt { get; set; }
        public int BackgroundImageWidth { get; set; }
        public int BackgroundImageHeight { get; set; }

    }
}
