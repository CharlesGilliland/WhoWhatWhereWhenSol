using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhoWhatWhereWhen.Models;

namespace WhoWhatWhereWhen.ViewModels
{
    public class EventFormViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<EventType> EventTypes { get; set; }
    }
}
