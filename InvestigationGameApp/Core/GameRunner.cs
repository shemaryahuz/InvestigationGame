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
        public static bool Run(GameLevel level)
        {
            Displayer.ShowRules(level.InvestigationRoom);
            return level.GameLoop();
        }
    }
}
