using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class AssetGroups : IdentityBase
    {
        [Display(Name = "Tên nhóm")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Mã nhóm tài sản"), Required]
        public string AssetGroupCode { get; set; }

        [Display(Name = "Thời gian trích khấu hao tối thiểu")]
        [Required]
        public int LifeTimeMin { get; set; }

        [Display (Name = "Thời gian trích khấu hao tối đa")]
        [Required]
        public int LifeTime { get; set; }
 
        [Display (Name = "Tỷ lệ hao mòn")]
        [Required]
        public float AtrophyPercent { get; set; }
    
        [Display (Name = "Thuộc về loại tài sản")]
        public AssetTypes AssetType { get; set;}
    }
}
