using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class TechnologyCard
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Class { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
