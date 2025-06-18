using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Sensors
{
    internal class PulseSensor: Sensor, ISensor
    {
        public PulseSensor(string name) : base(name, "pulse") { }
        private int capacity = 3;
        public override void Activate()
        {
            if (capacity > 0)
            {
                base.Activate();
                Console.WriteLine($"The sensor {Name} measures {Target.Type}'s heart rate...");
                capacity--;
            }
            else
            {
                Console.WriteLine($"The sensor {Name} is broken. You need to replace it");
            }
        }
    }
}
