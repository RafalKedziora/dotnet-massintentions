namespace Application.Interfaces
{
    public interface IIntentionService
    {
        ListIntentionsDto GetAllIntentions();
        IntentionDto GetIntentionById(int id);
        IntentionDto GetIntentionsByDate(DateTime date);
        IntentionDto AddNewIntention(CreateIntentionDto newIntention);
        void UpdateIntention(int id, UpdateIntentionDto intention);
        void DeleteIntention(int id);
    }
}
