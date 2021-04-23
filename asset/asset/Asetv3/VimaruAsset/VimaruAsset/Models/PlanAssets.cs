using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class PlanAssets :  IdentityBase
    {
       public enum BuyingMethods
        {
            Dauthau = 0,
            Chidinhthau = 1,
            Chaohang =2,
            Muasamtructiep =3
        }
        [Display(Name = "Tên tài sản")]
        public string Name { get; set; }

        [Display (Name = "Loại tài sản")]
        public AssetTypes Types { get; set; }
        
        [Display (Name = "Phương thức hình thành")]
        public string Method { get; set; }

        [Display (Name = "Đơn vị tính")]
        public Unit Unit { get; set; }

        [Display (Name = "Mô tả")]
        public string Describe { get; set; }

        [Display (Name = "Thời gian dự kiến")]
        [DataType(DataType.Date)]
        public DateTime TimeExpected { get; set; }

        [Display (Name = "Số lượng dự kiến")]
        public double AmountExpected { get; set; }

        [Display (Name = "Đơn giá dự kiến")]
        public double PriceExpected { get; set; }

        [Display (Name = "Hình thức mua sắm ")]
        public BuyingMethods BuyingMethod  { get; set; }

        [Display (Name = "Dự toán ĐD")]
        public double Estimate { get; set; }

        [Display (Name = "Ghi chú")]
        public string Note { get; set; }

        public Guid PlanId { get; set; }
    }
}
