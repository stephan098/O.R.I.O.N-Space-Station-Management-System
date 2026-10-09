using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    internal interface iPowerConsumer // Interface 1: For anything on the station that uses power
    {
        int PowerDraw { get; set; } // Interfaces isn't allowed to have fields but they are allowed to have properties (getter and setters)

        void AdjustPower(int powerLevel);        
    }
}
