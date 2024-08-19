using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class HomeAbout
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public string Caption { get; set; } = string.Empty;
        public List<TechnologyCard> TechnologyCards { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
