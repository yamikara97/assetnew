using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class AssetQR
    {
        public AssetsViewModel AssetInfo { get; set; }

        public Byte[] QRbitmap { get; set; }
    }
}
