using InvestigationGameApp.Controllers;

namespace InvestigationGameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            manager.RunAllLevels();
        }
    }
}
                                               