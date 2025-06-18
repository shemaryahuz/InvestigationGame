using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Agents
{
    // Class that represents FootAgent, has 2 weaknesses
    internal class FootSoldier: Agent, IAgent
    {
        private const int weaknessesLength = 2;
        public FootSoldier(string name, string[] weaknesses)
            : base(name, weaknesses, weaknessesLength) { }
    }
}
