using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class AssetsViewModel
    {
        public Assets Asset { get; set; }
        public ApplicationUser User { get; set; }
        public WareHouse Warehouse { get; set; }
        public Unit Unit { get; set; }
        public AssetTypes AssetType { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public Department Department { get; set; }

        public AssetGroups AssetGroups { get; set; }
        //public Exploit Exploit { get; set; }
    }
}
