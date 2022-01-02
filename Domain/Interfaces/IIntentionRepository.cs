using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IIntentionRepository
    {
        IQueryable<Intention> GetAll();
        Intention GetById(int id);
        Intention Add(Intention intention);
        void Update(Intention intention);
        void Delete(Intention intention);
    }
}
