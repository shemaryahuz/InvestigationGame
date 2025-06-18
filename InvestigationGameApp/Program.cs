using InvestigationGameApp.Core;

namespace InvestigationGameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game level1 = new Game("Foot Soldier");
            level1.Run();
            Game level2 = new Game("Squad Leader");
            level2.Run();
            Game level3 = new Game("Senior Commander");
            level3.Run();
            Game level4 = new Game("Organization Leader");
            level4.Run();
        }
    }
}
                                               