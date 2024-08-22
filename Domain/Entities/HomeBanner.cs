using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class HomeBanner
    {
        public int Id { get; set; }
        public required int BackgroundImageWidth { get; set; }
        public required int BackgroundImageHeight { get; set; }
        public required string BackgroundImageAlt { get; set; }
        public required string BackgroundImageSrc { get; set; }

        [NotMapped]
        public string BackgroundImageAvifSrc => BackgroundImageSrc + ".avif";
        
        [NotMapped]
        public string BackgroundImageWebpSrc => BackgroundImageSrc + ".webp";
        
        [NotMapped]
        public string BackgroundImageJpgSrc => BackgroundImageSrc + ".jpg";

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
