using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Sensors
{
    // base abstract class for implement base-sensor properties and methods for all sensors
    internal abstract class SensorBase : ISensor
    {
        protected SensorBase(string name, string type)
        {
            Name = name;
            Type = type;
        }
        public string Name { get; }
        public string Type { get; }
        public IAgent Target { get; set; }
        public bool IsActive { get; set; } = false;
        public virtual void Activate()
        {
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
