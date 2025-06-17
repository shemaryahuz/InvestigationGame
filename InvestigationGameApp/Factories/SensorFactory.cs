using InvestigationGameApp.Models.Interfaces;
using InvestigationGameApp.Models.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Factories
{
    internal class SensorFactory
    {
        public SensorFactory()
        {
            CreateSensors();
        }
        // Dictionary to save the sensors, string of the type as key and list of sensors as value
        public Dictionary<string, List<ISensor>> sensors = new Dictionary<string, List<ISensor>>
        {
            ["audio"] = new List<ISensor>(),
            ["thermal"] = new List<ISensor>()
        };
        public void CreateSensors()
        {
            // Add 20 audio sensors
            for (int i = 0; i < 20; i++)
            {
                AudioSensor audioSensor = new AudioSensor($"A{DateTime.Now.Millisecond}");
                sensors["audio"].Add(audioSensor);
            }
            // Add 20 thermal sensors
            for (int i = 0; i < 20; i++)
            {
                ThermalSensor thermalSensor = new ThermalSensor($"T{DateTime.Now.Millisecond}");
                sensors["thermal"].Add(thermalSensor);
            }
        }
    }
}
