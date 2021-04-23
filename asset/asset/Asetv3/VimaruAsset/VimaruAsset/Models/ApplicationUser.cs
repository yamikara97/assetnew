using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }

        public bool IsActive { get; set; } 
    
        public bool IsAdmin { get; set; }

        public Department Department { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? LastOnline { get; set; }
    }
}
