using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class Department : IdentityBase
    {
        [Display(Name = "Mã")]
        public string Code { get; set; }

        [Display(Name = "Tên vị trí quản lý")]
        public string Name { get; set; }

        [Display(Name = "Người quản lý trực tiếp")]
        public string ManagerName { get; set; }

        public string FatherID { get; set; }

        [Display (Name = "Ghi chú")]
        public string Note { get; set; }
    }
}
