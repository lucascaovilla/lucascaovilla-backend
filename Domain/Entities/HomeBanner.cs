using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class HomeBanner
    {
        public int Id { get; set; }
        public required int BackgroundImageWidth { get; set; }
        public required int BackgroundImageHeight { get; set; }
        public required string BackgroundImageAlt { get; set; } = string.Empty;

        public required string BackgroundImageSrc { get; set; }

        [NotMapped]
        public string BackgroundImageAvifSrc { get; private set; } = string.Empty;
        
        [NotMapped]
        public string BackgroundImageWebpSrc { get; private set; } = string.Empty;
        
        [NotMapped]
        public string BackgroundImageJpgSrc { get; private set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void UpdateImageSources()
        {
            BackgroundImageAvifSrc = BackgroundImageSrc + ".avif";
            BackgroundImageWebpSrc = BackgroundImageSrc + ".webp";
            BackgroundImageJpgSrc = BackgroundImageSrc + ".jpg";
        }
    }
}
