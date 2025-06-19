using InvestigationGameApp.Core;
using InvestigationGameApp.Factories;
using InvestigationGameApp.Models.Agents;
using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using InvestigationGameApp.Models.Sensors;
using InvestigationGameApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Core
{
    internal class GameLevel
    {
        public GameLevel(IAgent agent, int turns)
        {
            // Create room
            InvestigationRoom = new InvestigationRoom(agent);
            turnLimit = turns;
        }
        public InvestigationRoom InvestigationRoom;
        private SensorFactory sensorFactory = new SensorFactory();
        private int turnCount = 0;
        private int turnLimit;
        private void TryAttack()
        {
            // Attack if the agent is attacker and the turn got to the attacker's attack frequency
            if (InvestigationRoom.Agent is IAttacker attacker && turnCount % attacker.AttackFrequency == 0)
            {
                attacker.Attack();
            }
        }
        public bool GameLoop()
        {
            while (!InvestigationRoom.Agent.IsExposed && turnCount < turnLimit)
            {
                // increase turn count
                turnCount++;
                Displayer.ShowTurn(turnCount, turnLimit);
                Displayer.ShowStatus(InvestigationRoom);
                ISensor? sensor = null;
                string? sensorChoice = InputHandler.GetSensorChoice(sensorFactory);
                if (InputHandler.ValidateSensorChoice(sensorChoice, sensorFactory))
                {
                    // Get sensor
                    sensor = sensorFactory.GetSensor(sensorChoice);
                }
                else
                {
                    InputHandler.InvalidSensorMessage(sensorFactory);
                    continue;
                }
                int? slot = InputHandler.GetSlotChoice(InvestigationRoom);
                if (sensor != null && slot != null)
                {
                    InvestigationRoom.AttachSensor(sensor, (int)slot - 1);
                    InvestigationRoom.DeactivateSensors();
                    InvestigationRoom.ActivateSensors();
                    Displayer.ShowFoundWeaknesses(InvestigationRoom);
                }
                else
                {
                    InputHandler.InvalidSlotMessage(InvestigationRoom);
                }
                TryAttack();
            }
            if (InvestigationRoom.Agent.IsExposed)
            {
                Displayer.ShowWin(turnCount);
            }
            else
            {
                Displayer.ShowLose();
            }
            return InvestigationRoom.Agent.IsExposed;
        }
    }
}
