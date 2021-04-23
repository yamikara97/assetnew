using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VimaruAsset.Models
{
    public class ReductionHistory : IdentityBase
    {
        public string Reason { get; set; }
        public string FromDepartment { get; set; }
        public string ToDepartment { get; set; }
        public string Frombook { get; set; }
        public string ToBook { get; set; }
        public int NumberofAsset { get; set; }
        public DateTime DayMove { get; set; }
        public string PersonMove { get; set; }
    }
}
