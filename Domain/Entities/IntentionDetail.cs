namespace Domain.Entities
{
    public class IntentionDetail
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public int IntentionId { get; set; }
        public Intention Intention { get; set; }
    }
}
