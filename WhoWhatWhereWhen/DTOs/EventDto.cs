using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WhoWhatWhereWhen.Areas.Identity;

namespace WhoWhatWhereWhen.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        public EventTypeDto EventType { get; set; }

        [Required]
        public byte EventTypeId { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string HostId { get; set; }

        public ApplicationUser Host { get; set; }
    }
}
