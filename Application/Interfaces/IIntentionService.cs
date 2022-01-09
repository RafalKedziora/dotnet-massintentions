namespace Application.Interfaces
{
    public interface IIntentionService
    {
        ListIntentionsDto GetAllIntentions();
        ListIntentionsDto SearchByKeyword(string keyword);
        IntentionDto GetIntentionById(int id);
        ListIntentionsDto GetIntentionsByDate(DateTime date);
        IntentionDto AddNewIntention(CreateIntentionDto newIntention);
        void UpdateIntention(int id, UpdateIntentionDto intention);
        void DeleteIntention(int id);
    }
}
