using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class WareHouse : IdentityBase
    {
        public enum Status
        {
            AVAILABLE = 0,
            FULL = 1
        }
        [Display(Name = "Tên sổ")]
        public string Name { get; set; }
        
        [Display(Name = "Địa chỉ")]
        public  string Address { get; set; }

        [Display(Name = "Ghi chú")]
        public string WHStatus { get; set; }

        public Department department { get; set; }
    }
}
