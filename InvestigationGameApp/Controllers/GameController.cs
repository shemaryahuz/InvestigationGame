using InvestigationGameApp.Models;
using InvestigationGameApp.Models.Agents;
using InvestigationGameApp.Models.Base;
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
        private void StartGame()
        {
            // Create agent
            FootAgent agent = new FootAgent("Haminai");
            // Create room
            room = new InvestigationRoom();
            room.Agent = agent;

            Console.WriteLine(
                $"Investigation Game Started!\n" +
                $"Agent {agent.Name} is in the investigation room.\n" +
                $"Find all weaknesses to expose the agent!"
                );
        }
        private void GameLoop() { }
        private ISensor? CreateSensor(string type)
        {
            ISensor sensor = null;
            if (type == "audio")
            {
                sensor = new AudioSensor($"Audio Detector #{DateTime.Now.Millisecond}");
            }
            else if (type == "thermal")
            {
                sensor = new ThermalSensor($"Thermal Scanner #{DateTime.Now.Millisecond}");
            }
            return sensor;
        }
        private void ShowStatus()
        {

        }
        public void Run()
        {
            StartGame();
        }
    }
}
