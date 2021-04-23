using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class ShoppingPlan : IdentityBase
    {
        [Display(Name = "Tên kế hoạch")]
        public string Name { get; set; }
        [Display (Name = "Năm")]
        public int Year { get; set; }

        [Display (Name = "Nội dung")]
        public string Content { get; set; }

        [Display (Name = "Phục vụ đơn vị/ phòng ban")]
        public Guid Phongban { get; set; }
    }
}
