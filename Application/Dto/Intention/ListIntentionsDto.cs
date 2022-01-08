namespace Application.Dto
{
    public class ListIntentionsDto
    {
        public int Count { get; set; }
        public IEnumerable<IntentionDto> Intentions { get; set; }
    }
}
