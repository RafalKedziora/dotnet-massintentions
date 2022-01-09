namespace Application.Dto
{
    public class CreateIntentionDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime MassDate { get; set; }
        public int CategoryId { get; set; }
    }
}
