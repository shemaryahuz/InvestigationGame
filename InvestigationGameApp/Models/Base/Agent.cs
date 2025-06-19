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
        public Agent(string type, string[] weaknesses, int weaknessesLength)
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
        public virtual string GetData()
        {
            return $"Type: {Type} agent. Weaknesses Count: {Weaknesses.Length}.";
        }
    }
}
