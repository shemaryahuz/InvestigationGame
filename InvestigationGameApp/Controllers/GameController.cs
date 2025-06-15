using InvestigationGameApp.Models;
using InvestigationGameApp.Models.Interfaces;
using InvestigationGameApp.Models.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Controllers
{
    internal class GameController
    {
        private InvestigationRoom room;

        public void StartGame() { }
        public void GameLoop() { }
        public ISensor? CreateSensor(string type)
        {
            ISensor sensor = null;
            if (type == "audio")
            {
                
            }
            else if (type == "thermal")
            {

            }
            return sensor;
        }
        public void ShowStatus()
        {

        }
    }
}
