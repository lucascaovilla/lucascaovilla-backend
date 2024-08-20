using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class HomePortfolio
    {
        public int Id { get; set; }
        public required string BackgroundImageSrc { get; set; }
        public List<ProjectCard> ProjectCards { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
