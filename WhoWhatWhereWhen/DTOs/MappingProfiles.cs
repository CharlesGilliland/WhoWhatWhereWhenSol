using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhoWhatWhereWhen.Models;

namespace WhoWhatWhereWhen.DTOs
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();

            CreateMap<EventType, EventTypeDto>();
            CreateMap<EventTypeDto, EventType>();
        }
    }
}
