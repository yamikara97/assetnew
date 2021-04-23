using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class Manufacturer :IdentityBase
    {
        [Display(Name = "Nhà cung cấp")]
        public string Name { get; set; }

        [Display(Name = "Số điện thoại")]
        [MaxLength(10, ErrorMessage ="Số điện thoại bao gồm 10 chữ số")]
        public string PhoneNo { get; set; }

        [Display(Name = "Địa chỉ")]
        public  string Address { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
    }
}
