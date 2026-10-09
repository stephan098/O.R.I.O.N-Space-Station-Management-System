using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    internal class ResearchLab : StationModule, iPowerConsumer, iMaintainable // Derived classes representing specific station parts (Inheritence)
    {
        private int powerDraw;
        private int integrityLevel;
        private int activeExperiments;

        public ResearchLab(string moduleID, bool isOnLine, int powerDraw, int integrityLevel, int activeExperiments) : base(moduleID, isOnLine)
        {
            this.powerDraw = powerDraw;
            this.integrityLevel = integrityLevel;
            this.activeExperiments = activeExperiments;
        }

        public int PowerDraw { get => powerDraw; set => powerDraw = value; }
        public int IntegrityLevel { get => integrityLevel; set => integrityLevel = value; }

        public void AdjustPower(int powerLevel)
        {
            PowerDraw = powerLevel;
        }

        public void PerformMaintenance()
        {
            IntegrityLevel = 100;
        }

        public override void RunDiagnostics()
        {
            Console.WriteLine($"--- DIAGNOSTICS: Research Lab [{ModuleID}] ---");
            Console.WriteLine($"Status: {(IsOnLine ? "ONLINE" : "OFFLINE")} | Integrity: {integrityLevel}% | Power: {PowerDraw} units | Active Experiments: {activeExperiments}");
        }
    }
}
