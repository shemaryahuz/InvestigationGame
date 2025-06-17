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
        private int nextSlot = 0;
        public void AttachSensor(ISensor sensor)
        {
            Agent.AttachedSensors[nextSlot] = sensor;
            nextSlot++;
            if (nextSlot >= Agent.AttachedSensors.Length)
            {
                nextSlot = 0;
            }
        }
        public int GetMatchCount()
        {
            int matchCount = 0;
            // Make bool arr of foundSensors
            bool[] weaknessesFound = new bool[Agent.Weaknesses.Length];
            // Loop over the attached sensors
            for (int i = 0; i < Agent.AttachedSensors.Length; i++)
            {
                // Go to the attached sensors
                if (Agent.AttachedSensors[i] != null && Agent.AttachedSensors[i].IsActive)
                {
                    // Check if the attached sensor is in weaknesses
                    for (int j = 0; j < Agent.Weaknesses.Length; j++)
                    {
                        if (!weaknessesFound[j] && Agent.Weaknesses[i] == Agent.AttachedSensors[i].Type)
                        {
                            weaknessesFound[j] = true;
                            matchCount++;
                            break;
                        }
                    }
                }
                // If all the weaknesses found update IsExposed
                if (matchCount >= Agent.Weaknesses.Length)
                {
                    Agent.IsExposed = true;
                }
            }
            return matchCount;
        }
    }
}
