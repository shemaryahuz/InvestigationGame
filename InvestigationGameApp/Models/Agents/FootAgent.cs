using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Agents
{
    // Class that represents FootAgent, has 2 weaknesses from 2 types
    internal class FootAgent: Agent, IAgent
    {
        public FootAgent(string name, int weaknessesAmount, string[] sensorTypes) : base(name, 2, new string[] { "Audio", "Thermal" }) { }
    }
}
