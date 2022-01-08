namespace Domain.Interfaces
{
    public interface IIntentionRepository
    {
        IQueryable<Intention> GetAll();
        Intention GetById(int id);
        IQueryable<Intention> GetByDate(DateTime date);
        Intention Add(Intention intention);
        void Update(Intention intention);
        void Delete(Intention intention);
    }
}
