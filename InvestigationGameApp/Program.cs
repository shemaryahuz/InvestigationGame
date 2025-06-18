using InvestigationGameApp.Core;

namespace InvestigationGameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLevel level1 = new GameLevel("Foot Soldier");
            level1.Run();
            GameLevel level2 = new GameLevel("Squad Leader");
            level2.Run();
            GameLevel level3 = new GameLevel("Senior Commander");
            level3.Run();
            GameLevel level4 = new GameLevel("Organization Leader");
            level4.Run();
        }
    }
}
                                               