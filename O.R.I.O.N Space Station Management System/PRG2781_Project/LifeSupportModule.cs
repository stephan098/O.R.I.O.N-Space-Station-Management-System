using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    internal class LifeSupportModule : StationModule, iPowerConsumer, iMaintainable // Derived classes representing specific station parts (Inheritence)
    {
        private int powerDraw; // Fields required by the interfaces
        private int integrityLevel;

        public LifeSupportModule(string moduleID, bool isOnLine, int powerDraw, int integrityLevel) : base(moduleID, isOnLine) // Constructor, with randomized data
        {
            Random rand = new Random();
            this.PowerDraw = powerDraw = rand.Next(50,101); // Random Health between 50% and 100%
            this.IntegrityLevel = integrityLevel = rand.Next(100, 501); // Random power draw between 100 and 500 units
        }

        public int PowerDraw { get => powerDraw; set => powerDraw = value; } // getter and setters & fulfilling the interfaces
        public int IntegrityLevel { get => integrityLevel; set => integrityLevel = value; }


        public void AdjustPower(int powerLevel)
        {
            PowerDraw = powerLevel;
            Console.WriteLine($"[Life Support {ModuleID}] Power adjusted to {PowerDraw} units");
        }

        public void PerformMaintenance()
        {
            IntegrityLevel = 100; // Repair it back to full
            Console.WriteLine($"[Life Support] {ModuleID} Maintenance complete. Integrity at 100%");
        }

        public override void RunDiagnostics() // Method overriding 
        {
            Console.WriteLine($"--- DIAGNOSTICS: Life Support [{ModuleID}] ---");
            Console.WriteLine($"Status: {(IsOnLine ? "ONLINE" : "OFFLINE")} | Integrity: {IntegrityLevel}% | Power: {PowerDraw} units");
        }
    }
}
