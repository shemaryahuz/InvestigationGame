using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Sensors
{
    internal class ThermalSensor: SensorBase, ISensor
    {
        public override string Type { get; set; } = "Thermal";
    }
}
