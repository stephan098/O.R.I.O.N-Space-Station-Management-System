using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    internal class SolarArray : StationModule, iMaintainable
    {
        private int integrityLevel;
        private int powerGenerated;


        public SolarArray(string moduleID, bool isOnLine, int integrityLevel, int powerGenerated) : base(moduleID, isOnLine)
        {
            Random rand = new Random();
            this.integrityLevel = integrityLevel = rand.Next(40, 101);
            this.powerGenerated = powerGenerated = rand.Next(800, 1500);
        }

        public int IntegrityLevel { get => integrityLevel; set => integrityLevel = value; }

        public void PerformMaintenance()
        {
            IntegrityLevel = 100;
        }

        public override void RunDiagnostics()
        {
            Console.WriteLine($"--- DIAGNOSTICS: Solar Array [{ModuleID}] ---");
            Console.WriteLine($"Status: {(IsOnLine ? "ONLINE" : "OFFLINE")} | Integrity: {IntegrityLevel}% | Power Output: +{powerGenerated} units");
        }
    }
}
