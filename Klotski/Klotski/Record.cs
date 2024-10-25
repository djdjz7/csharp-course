using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klotski
{
    internal class Record
    {
        public int? BestSteps { get; set; }
        public TimeSpan? BestTime { get; set; }
    }
}
