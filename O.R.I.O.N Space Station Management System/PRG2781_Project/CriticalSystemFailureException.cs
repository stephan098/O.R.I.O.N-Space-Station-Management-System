using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    internal class CriticalSystemFailureException : Exception // Creates the custom exception and inherits from the base Exception class
    {
        public CriticalSystemFailureException(string message) : base(message) // Constructer allows custom error message
        { 
        } 
    }
}
