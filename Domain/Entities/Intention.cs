namespace Domain.Entities
{
    public class Intention
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime MassDate { get; set; }
        public IntentionDetail Detail { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
