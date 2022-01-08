namespace Application.Services
{
    public class IntentionService : IIntentionService
    {
        private readonly IIntentionRepository _intentionRepository;
        private readonly IMapper _mapper;
        public IntentionService(IIntentionRepository intentionRepository, IMapper mapper)
        {
            _intentionRepository = intentionRepository;
            _mapper = mapper;
        }

        public ListIntentionsDto GetAllIntentions()
        {
            var intentions = _intentionRepository.GetAll();
            return _mapper.Map<ListIntentionsDto>(intentions);
        }

        public IntentionDto GetIntentionById(int id)
        {
            var intention = _intentionRepository.GetById(id);
            return _mapper.Map<IntentionDto>(intention);
        }

        public IntentionDto GetIntentionsByDate(DateTime date)
        {
            var intention = _intentionRepository.GetByDate(date);
            return _mapper.Map<IntentionDto>(intention);
        }

        public IntentionDto AddNewIntention(CreateIntentionDto newIntention)
        {
            if(string.IsNullOrEmpty(newIntention.Title))
            {
                throw new Exception("Intention can't have an empty title");
            }

            var intention = _mapper.Map<Intention>(newIntention);

            intention.Detail = new IntentionDetail()
            {
                Created = DateTime.Now,
                LastModified = DateTime.Now
            };

            _intentionRepository.Add(intention);
            return _mapper.Map<IntentionDto>(intention);
        }

        public void UpdateIntention(int id, UpdateIntentionDto intention)
        {
            if (string.IsNullOrEmpty(intention.Title))
            {
                throw new Exception("Intention can't have an empty title");
            }

            var existingIntention = _intentionRepository.GetById(id);

            var updatedIntention = _mapper.Map(intention, existingIntention);
            updatedIntention.Detail.LastModified = DateTime.Now;
            _intentionRepository.Update(updatedIntention);
        }

        public void DeleteIntention(int id)
        {
            var intention = _intentionRepository.GetById(id);
            _intentionRepository.Delete(intention);
        }
    }
}
