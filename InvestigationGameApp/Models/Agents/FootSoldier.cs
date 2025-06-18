using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Agents
{
    // Class that represents FootAgent, has 2 weaknesses
    internal class FootSoldier: AgentBase, IAgent
    {
        private const int weaknessesLength = 2;
        public FootSoldier(string[] weaknesses)
            : base("Foot Soldier", weaknesses, weaknessesLength) { }
    }
}
