using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Agents
{
    // Class that represents FootAgent, has 5 weaknesses from 2 types
    internal class FootSoldier: Agent, IAgent
    {
        public FootSoldier(string name, string[] weaknesses) : base(name, weaknesses) { }
    }
}
