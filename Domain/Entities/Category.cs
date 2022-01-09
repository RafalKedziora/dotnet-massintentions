namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Intention> Intentions { get; set; }
    }
}
