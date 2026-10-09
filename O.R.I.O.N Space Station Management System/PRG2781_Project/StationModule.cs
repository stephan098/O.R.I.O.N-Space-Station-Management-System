using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    abstract class StationModule
    {
        private string moduleID; // Private fields with public properties (Encapsulation)
        private bool isOnLine;

        public StationModule(string moduleID, bool isOnLine)
        {
            this.ModuleID = moduleID;
            this.IsOnLine = isOnLine;
        }

        public string ModuleID { get => moduleID; set => moduleID = value; }
        public bool IsOnLine { get => isOnLine; set => isOnLine = value; }

        public abstract void RunDiagnostics(); // An abstract method that forces child classes to override it (Polymorphism)

        public override string ToString() // override method for ToString method
        {
            return $"Type: {this.GetType().Name} | ID: {this.ModuleID}"; // gets the module name and id and then sends it to the saved file
        }
    }
}
