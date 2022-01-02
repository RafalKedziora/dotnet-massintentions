using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<IntentionDto> GetAllIntentions()
        {
            var intentions = _intentionRepository.GetAll();
            return _mapper.Map<IEnumerable<IntentionDto>>(intentions);
        }

        public IntentionDto GetIntentionById(int id)
        {
            var intention = _intentionRepository.GetById(id);
            return _mapper.Map<IntentionDto>(intention);
        }

        public IntentionDto AddNewIntention(CreateIntentionDto newIntention)
        {
            if(string.IsNullOrEmpty(newIntention.Title))
            {
                throw new Exception("Intention can't have an empty title");
            }

            var intention = _mapper.Map<Intention>(newIntention);
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
            _intentionRepository.Update(updatedIntention);
        }

        public void DeleteIntention(int id)
        {
            var intention = _intentionRepository.GetById(id);
            _intentionRepository.Delete(intention);
        }
    }
}
