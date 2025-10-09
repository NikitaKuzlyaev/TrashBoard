namespace TrashBoard.Api.DTOs
{
    public record ThreadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishedAt { get; set; } 
    }

}
