using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWhatWhereWhen.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(500)]
        public string Bio { get; set; }
    }
}
