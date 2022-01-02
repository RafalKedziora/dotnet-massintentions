using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                #region Intentions

                cfg.CreateMap<Intention, IntentionDto>();
                cfg.CreateMap<CreateIntentionDto, Intention>();
                cfg.CreateMap<UpdateIntentionDto, Intention>();

                #endregion
            }).CreateMapper();
    }
}
