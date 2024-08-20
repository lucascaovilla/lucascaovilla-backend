namespace Application.DTOs
{
    public class ProjectCardDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Link { get; set; }
    }
}
