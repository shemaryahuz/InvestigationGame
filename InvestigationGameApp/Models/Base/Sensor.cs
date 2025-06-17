using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Base
{
    // base abstract class for implement base-sensor properties and methods for all sensors
    internal abstract class Sensor: ISensor
    {
        public Sensor(string name, string type)
        {
            Name = name;
            Type = type;
        }
        public string Name { get; }
        public string Type { get; }
        public bool IsActive { get; set; } = false;
        public virtual void Activate()
        {
            IsActive = true;
        }
        public IAgent Target { get; set; }
    }
}
