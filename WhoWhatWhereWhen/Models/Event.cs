using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WhoWhatWhereWhen.Areas.Identity;

namespace WhoWhatWhereWhen.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        public EventType EventType { get; set; }

        [Required]
        public byte EventTypeId { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string HostId { get; set; }

        public ApplicationUser Host { get; set; }

        public IEnumerable<string> Attending { get; set; }
    }

    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(x => x.DateAndTime).NotNull().GreaterThan(x => DateTime.Now).WithMessage("The event must be hosted some time in the future");
        }
    }
}
