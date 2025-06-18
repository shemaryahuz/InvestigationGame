using InvestigationGameApp.Core;

namespace InvestigationGameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game level1 = new Game("footSoldier");
            level1.Run();
            Game level2 = new Game("squadLeader");
            level2.Run();
        }
    }
}
                                               