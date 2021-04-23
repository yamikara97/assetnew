using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class Assets : IdentityBase
    {
        public enum Statuses
        {
            GOOD = 0,
            BAD = 1,
            MAINTENANCE = 2,
            RENT = 3,
            DESTROY = 4,
            SELL = 5,
            WITHDRAW = 6
        }

        [Display(Name = "Tên tài sản")]
        public string Name { get; set;  }

        [Display(Name = "Mã tài sản")]
        [MaxLength(15)]
        public string Code { get; set; }

        [Display(Name = "Ngày sản  xuất")]
        [DataType(DataType.Date)]
        public DateTime MFG { get; set; } 

        [Display(Name = "Hạn bảo hành")]
        [DataType(DataType.Date)]
        public DateTime Guarantee { get; set; }

        [Display(Name = "Địa chỉ / Đặt tại")]
        public string Address { get; set; }
        
        [Display (Name = "Số liệu kỹ thuật")]
        public string TechnicalData { get; set; }

        [Display(Name = "Tổng nguyên giá")]
        public double Price { get; set; }  

        [Display(Name = "Tình trạng")]
        public Statuses Status { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [Display(Name = "Nguồn ngân sách")]
        public double BudgetSource { get; set; }

        [Display(Name = "Nguồn sự nghiệp")]
        public double CareerSource { get; set; }

        [Display (Name = "Nguồn viện trợ")]
        public double AidSource { get; set; }

        [Display (Name = "Nguồn khác")]
        public double AnotherSource { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public Unit Unit { get; set; }
        
        public AssetTypes Type   { get; set; }  

        public AssetGroups AssetGroups { get; set; }

        public WareHouse WareHouse { get; set; }

        [Display(Name = "Số chỗ ngồi")]
        public int SeatNumber { get; set; }

        [Display(Name = "Biển kiểm soát")]
        public string VehiclePlate { get; set; }

        [Display(Name = "Tải trọng")]
        public float WeightHandle { get; set; }

        [Display(Name = "Công suất")]
        public string Wattage { get; set; }

        [Display (Name = "Lý do tăng")]
        public string Reason { get; set; }

        [Display (Name = "Hiện trạng sử dụng")]
        public string CurrentUses { get; set; }

        [Display (Name = "Ngày đưa vào sử dụng")]
        [DataType(DataType.Date)]
        public DateTime DateUse { get; set; }

        [Display(Name = "Số lượng")]
        [DefaultValue(1)]
        public int Amount { get; set; } = 1;

        public bool IsConfirm { get; set; }

        public Guid identify { get; set; }

    }
}
