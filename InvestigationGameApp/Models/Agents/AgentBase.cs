using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Agents
{
    // base abstract class for implement base-agent properties and methods for all agents
    internal abstract class AgentBase: IAgent
    {
        public AgentBase(string type, string[] weaknesses, int weaknessesLength)
        {
            // Validate weaknesses length
            if (weaknesses.Length != weaknessesLength)
            {
                throw new ArgumentException(
                    $"{GetType().Name} must have exactly {weaknessesLength} weaknesses."
                    );
            }
            // Initialize properties  
            Type = type;
            Weaknesses = weaknesses;
            AttachedSensors = new ISensor[weaknessesLength];
        }
        public string Type { get; }
        public string[] Weaknesses { get; set; }
        public ISensor[] AttachedSensors { get; set; }
        public bool IsExposed { get; set; } = false;
    }
}
