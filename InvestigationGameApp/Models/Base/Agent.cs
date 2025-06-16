using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Base
{
    // base abstract class for implement base-agent properties and methods for all agents
    internal abstract class Agent: IAgent
    {
        public Agent(string name, int weaknessesAmount, string[] sensorTypes)
        {
            // Initialize properties  
            Name = name;
            Weaknesses = new string[weaknessesAmount];
            AttachedSensors = new ISensor[weaknessesAmount];
            // Add random weaknesses from sensorTypes
            Random random = new Random();
            for (int i = 0; i < weaknessesAmount; i++)
            {
                int randomIndex = random.Next(sensorTypes.Length);
                Weaknesses[i] = sensorTypes[randomIndex];
            }
        }
        public string Name { get; }
        public string[] Weaknesses { get; set; }
        public ISensor[] AttachedSensors { get; set; }
        public bool IsExposed { get; set; } = false;
        private int nextSlot = 0;
        public void AttachSensor(ISensor sensor)
        {
            AttachedSensors[nextSlot] = sensor;
            nextSlot++;
            if (nextSlot >= AttachedSensors.Length)
            {
                nextSlot = 0;
            }
        }
        public int GetMatchCount()
        {
            int matchCount = 0;
            // Make bool arr of foundSensors
            bool[] weaknessesFound = new bool[Weaknesses.Length];
            // Loop over th attached sensors
            for (int i = 0; i < AttachedSensors.Length; i++)
            {
                // Go to the attached sensors
                if (AttachedSensors[i] != null && AttachedSensors[i].IsActive)
                {
                    // Check if the attached sensor is in weaknesses
                    for (int j = 0; j < Weaknesses.Length; j++)
                    {
                        if (!weaknessesFound[j] && Weaknesses[i] == AttachedSensors[i].Type)
                        {
                            weaknessesFound[j] = true;
                            matchCount++;
                            break;
                        }
                    }
                }
            }
            return matchCount;
        }
    }
}
