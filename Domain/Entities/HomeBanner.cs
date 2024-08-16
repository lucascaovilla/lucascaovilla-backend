namespace Domain.Entities
{
    public class HomeBanner
    {
        public int Id { get; set; }
        public string BackgroundImageAvifSrc { get; set; }
        public string BackgroundImageWebpSrc { get; set; }
        public string BackgroundImageSrc { get; set; }
        public string BackgroundImageAlt { get; set; }
        public int BackgroundImageWidth { get; set; }
        public int BackgroundImageHeight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public HomeBanner()
        {
            BackgroundImageAvifSrc = string.Empty;
            BackgroundImageWebpSrc = string.Empty;
            BackgroundImageSrc = string.Empty;
            BackgroundImageAlt = string.Empty;
            BackgroundImageWidth = 0;
            BackgroundImageHeight = 0;
        }
    }
}