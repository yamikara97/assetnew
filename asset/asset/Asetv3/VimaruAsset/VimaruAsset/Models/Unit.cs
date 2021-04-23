using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class Unit : IdentityBase
    {
        [Display(Name = "Đơn vị tính "), Required]

        public string UnitName { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
    }
}
