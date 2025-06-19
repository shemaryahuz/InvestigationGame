using InvestigationGameApp.Controllers;

namespace InvestigationGameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LevelManager manager = new LevelManager();
            manager.RunAllLevels();
        }
    }
}
                                               