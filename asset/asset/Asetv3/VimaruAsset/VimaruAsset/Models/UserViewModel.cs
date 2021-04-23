using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class UserViewModel
    {
        public ApplicationUser user { get; set; }
        public IdentityRole<Guid> role { get; set; }
        public Department department { get; set; }
    }
}
