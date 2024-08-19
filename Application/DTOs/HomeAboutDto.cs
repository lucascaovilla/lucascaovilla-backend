namespace Application.DTOs
{
    public class HomeAboutDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Caption { get; set; }
        public List<TechnologyCardDto> TechnologyCards { get; set; } = [];

    }
}
