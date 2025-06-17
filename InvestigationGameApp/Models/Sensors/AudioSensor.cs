using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Sensors
{
    // Class that represents AudioSensor
    internal class AudioSensor: Sensor, ISensor
    {
        public AudioSensor(string name) : base(name, "audio") { }
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine($"The sensor {Name} is recording audio of {Target.Name}...");
        }
        public override string GetData()
        {
            return $"{base.GetData()} Features: Can recording audio.";
        }
    }
}
