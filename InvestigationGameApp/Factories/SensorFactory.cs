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
        private static SensorFactory _instance;
        private SensorFactory()
        {
            CreateSensors();
        }
        public static SensorFactory GetInstance()
        {
            if (_instance is null)
            {
                _instance = new SensorFactory();
            }
            return _instance;
        }
        // Dictionary to save the sensors, string of the type as key and list of sensors as value
        public Dictionary<string, List<ISensor>> Sensors { get; set; } = new Dictionary<string, List<ISensor>>
        {
            ["audio"] = new List<ISensor>(),
            ["thermal"] = new List<ISensor>(),
            ["pulse"] = new List<ISensor>()
        };
        public void CreateSensors()
        {
            // Add 5 audio sensors
            for (int i = 0; i < 5; i++)
            {
                AudioSensor audioSensor = new AudioSensor($"A{DateTime.Now.Millisecond}{i}");
                Sensors["audio"].Add(audioSensor);
            }
            // Add 5 thermal sensors
            for (int i = 0; i < 5; i++)
            {
                ThermalSensor thermalSensor = new ThermalSensor($"T{DateTime.Now.Millisecond}{i}");
                Sensors["thermal"].Add(thermalSensor);
            }
            // Add 5 pulse sensors
            for (int i = 0; i < 5; i++)
            {
                PulseSensor pulseSensor = new PulseSensor($"P{DateTime.Now.Millisecond}{i}");
                Sensors["pulse"].Add(pulseSensor);
            }
        }
        public ISensor? GetSensor(string sensorType)
        {
            ISensor sensor = null;
            if (Sensors.ContainsKey(sensorType) && Sensors[sensorType].Count > 0)
            {
                Random random = new Random();
                int index = random.Next(Sensors[sensorType].Count);
                sensor = Sensors[sensorType][index];
            }
            return sensor;
        }
    }
}
