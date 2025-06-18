using InvestigationGameApp.Core;

namespace InvestigationGameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game controller = Game.GetInstance();
            controller.Run();
        }
    }
}
                                               