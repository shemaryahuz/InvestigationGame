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
            GameLevel level1 = new GameLevel("Foot Soldier");
            GameRunner.Run(level1);
            GameLevel level2 = new GameLevel("Squad Leader");
            GameRunner.Run(level2);
            GameLevel level3 = new GameLevel("Senior Commander");
            GameRunner.Run(level3);
            GameLevel level4 = new GameLevel("Organization Leader");
            GameRunner.Run(level4);
        }
    }
}
