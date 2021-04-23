using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class Privacy
    {
        public DateTime DateEnd1 { get; } = DateTime.ParseExact("28/04/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        public DateTime DateEnd2 { get; } = DateTime.ParseExact("30/05/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}
