using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IIntentionService
    {
        IEnumerable<IntentionDto> GetAllIntentions();
        IntentionDto GetIntentionById(int id);
        IntentionDto AddNewIntention(CreateIntentionDto newIntention);
        void UpdateIntention(int id, UpdateIntentionDto intention);
        void DeleteIntention(int id);
    }
}
