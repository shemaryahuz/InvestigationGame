using InvestigationGameApp.GameData;
using InvestigationGameApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Core
{
    internal static class GameRunner
    {
        public static void Run(GameLevel level)
        {
            level.ShowRules();
            level.GameLoop();
        }
    }
}
