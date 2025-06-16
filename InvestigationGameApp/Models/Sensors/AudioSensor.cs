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
        public AudioSensor(string name) : base(name) { }
        public override string Type { get; } = "Audio";
    }
}
