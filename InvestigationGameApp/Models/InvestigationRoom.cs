using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models
{
    internal class InvestigationRoom
    {
        public IAgent Agent { get; set; }
        public string[] AvailableSensors { get; set; } = { "Audio", "Thermal" };
        public void ActivateSensors()
        {
            foreach (ISensor sensor in Agent.AttachedSensors)
            {
                if (sensor != null)
                {
                    sensor.Activate();
                }
            }
        }
    }
}
