using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Sensors
{
    // Class that represents ThermalSensor
    internal class ThermalSensor : SensorBase, ISensor
    {
        public ThermalSensor(string name) : base(name, "thermal") { }
        private int nextWeakness = 0;
        public override void Activate()
        {
            base.Activate();
            if (nextWeakness >= Target.Weaknesses.Length)
            {
                nextWeakness = 0;
            }
            Console.WriteLine(
                $"The sensor {Name} is checking {Target.Type}'s temperature... " +
                $"weakness {nextWeakness + 1} found! it's {Target.Weaknesses[nextWeakness]}");
            nextWeakness++;
        }
    }
}
