using InvestigationGameApp.Models.Agents;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Core
{
    internal class InvestigationRoom
    {
        public InvestigationRoom(IAgent agent)
        {
            Agent = agent;
        }
        public IAgent Agent { get; set; }
        public ISensor[] AvailableSensors { get; set; }
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
        private string[] GetRandomWeaknesses(int amount, string[] types)
        {
            string[] weaknesses = new string[amount];
            // Add random weaknesses from sensorTypes
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                int randomIndex = random.Next(types.Length);
                weaknesses[i] = types[randomIndex];
            }
            return weaknesses;
        }
    }
}
