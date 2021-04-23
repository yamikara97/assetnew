
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class AssetTypes : IdentityBase
    {
        [Display(Name = "Tên loại tài sản"), Required]
        public string AssetTypeName { get; set; }

        [Display(Name = "Mã loại tài sản"), Required]
        public string AssetTypeCode { get; set; }

        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }
    }
}
