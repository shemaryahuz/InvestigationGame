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
        public Agent(string name, string[] weaknesses)
        {
            // Initialize properties  
            Name = name;
            Weaknesses = weaknesses;
            AttachedSensors = new ISensor[weaknesses.Length];
        }
        public string Name { get; }
        public string[] Weaknesses { get; set; }
        public ISensor[] AttachedSensors { get; set; }
        public bool IsExposed { get; set; } = false;
    }
}
