using InvestigationGameApp.Controllers;

namespace InvestigationGameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController controller = GameController.GetInstance();
            controller.Run();
        }
    }
}
                                               