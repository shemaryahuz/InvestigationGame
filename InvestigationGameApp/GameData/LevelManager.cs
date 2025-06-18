using InvestigationGameApp.Core;
using InvestigationGameApp.Factories;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.GameData
{
    internal class LevelManager
    {
        public void RunAllLevels()
        {
            GameLevel level1 = new GameLevel(AgentFactory.CreateFootSoldier());
            GameRunner.Run(level1);
            GameLevel level2 = new GameLevel(AgentFactory.CreateSquadLeader());
            GameRunner.Run(level2);
            GameLevel level3 = new GameLevel(AgentFactory.CreateSeniorCommander());
            GameRunner.Run(level3);
            GameLevel level4 = new GameLevel(AgentFactory.CreateOrganizationLeader());
            GameRunner.Run(level4);
        }
    }
}
