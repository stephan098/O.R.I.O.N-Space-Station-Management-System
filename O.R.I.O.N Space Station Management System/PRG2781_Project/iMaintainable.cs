using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    internal interface iMaintainable // Interface 2: For anything that can be repaired by engineers
    {
        int IntegrityLevel { get; set; }

        void PerformMaintenance();
    }
}
