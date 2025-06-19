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
        public SensorFactory(int quantity)
        {
            _quantity = quantity;
            CreateAudioSensors();
            CreateThermalSensors();
            CreatePulseSensors();
        }
        // Dictionary to save the sensors, string of the type as key and list of sensors as value
        public Dictionary<string, List<ISensor>> Sensors { get; set; } = new Dictionary<string, List<ISensor>>
        {
            ["audio"] = new List<ISensor>(),
            ["thermal"] = new List<ISensor>(),
            ["pulse"] = new List<ISensor>()
        };
        private int _quantity;
        public void CreateAudioSensors()
        {
            // Add audio sensors
            for (int i = 0; i < _quantity; i++)
            {
                AudioSensor audioSensor = new AudioSensor($"microphone{i}");
                Sensors["audio"].Add(audioSensor);
            }
        }
        public void CreateThermalSensors()
        {
            // Add thermal sensors
            for (int i = 0; i < _quantity; i++)
            {
                ThermalSensor thermalSensor = new ThermalSensor($"detector{i}");
                Sensors["thermal"].Add(thermalSensor);
            }
        }
        public void CreatePulseSensors()
        {
            // Add pulse sensors
            for (int i = 0; i < _quantity; i++)
            {
                PulseSensor pulseSensor = new PulseSensor($"amped{i}");
                Sensors["pulse"].Add(pulseSensor);
            }
        }
        public ISensor? GetSensor(string sensorType)
        {
            ISensor sensor = null!;
            if (Sensors.ContainsKey(sensorType) && Sensors[sensorType].Count > 0)
            {
                Random random = new Random();
                int index = random.Next(Sensors[sensorType].Count);
                sensor = Sensors[sensorType][index];
                while (sensor.IsActive)
                {
                    index = random.Next(Sensors[sensorType].Count);
                    sensor = Sensors[sensorType][index];
                }
            }
            return sensor;
        }
    }
}
