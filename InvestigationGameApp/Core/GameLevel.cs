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
        public GameLevel(IAgent agent)
        {
            // Create room
            InvestigationRoom = new InvestigationRoom(agent);
        }
        public InvestigationRoom InvestigationRoom;
        private SensorFactory sensorFactory = SensorFactory.GetInstance();
        private int turnCount = 0;
        private int turnLimit = 10;
        private void ShowStatus()
        {
            // Show match count
            Console.WriteLine(
                $"Agent {InvestigationRoom.Agent.Type}.\n" +
                $"Weaknesses found: {InvestigationRoom.GetMatchCount()}/{InvestigationRoom.Agent.Weaknesses.Length}"
                );
            // Show current attached sensors
            Console.WriteLine("Current sensors:");
            for (int i = 0; i < InvestigationRoom.Agent.AttachedSensors.Length; i++)
            {
                if (InvestigationRoom.Agent.AttachedSensors[i] != null)
                {
                    ISensor slot = InvestigationRoom.Agent.AttachedSensors[i];
                    Console.WriteLine($"Slot {i + 1}: {slot.Type} {slot.Name} - Active: {slot.IsActive}");
                }
                else
                {
                    Console.WriteLine($"Slot {i + 1}: Empty");
                }
            }
        }
        private string? GetSensorChoice()
        {
            // Get sensor choice
            Console.WriteLine("Choose sensor type from the fallowing:");
            foreach(string type in sensorFactory.Sensors.Keys)
            {
                Console.WriteLine($"'{type}'");
            }
            string? sensorChoice = Console.ReadLine()?.ToLower();
            return sensorChoice;
        }
        private int? GetSlotChoice()
        {
            // Get slot choice
            Console.WriteLine($"Choose slot to attach in (from 1 to {InvestigationRoom.Agent.AttachedSensors.Length})");
            string? slotChoice = Console.ReadLine();
            if ((int.TryParse(slotChoice, out int slot)) && slot >= 1 && slot <= InvestigationRoom.Agent.AttachedSensors.Length)
            {
                return slot;
            }
            return null;
        }
        private void TryAttack()
        {
            // Attack if the agent is attacker and the turn got to the attacker's attack frequency
            if (InvestigationRoom.Agent is IAttacker attacker && turnCount % attacker.AttackFrequency == 0)
            {
                attacker.Attack();
            }
        }
        public void GameLoop()
        {
            while (!InvestigationRoom.Agent.IsExposed && turnCount < turnLimit)
            {
                // increase turn count
                turnCount++;
                Displayer.ShowTurn(turnCount, turnLimit);
                ShowStatus();
                ISensor? sensor = null;
                string? sensorChoice = GetSensorChoice();
                if (sensorChoice != null && sensorFactory.Sensors.ContainsKey(sensorChoice))
                {
                    // Get sensor
                    sensor = sensorFactory.GetSensor(sensorChoice);
                }
                else
                {
                    Console.WriteLine("Invalid sensor type! Use one of the fallowing:");
                    foreach (string type in sensorFactory.Sensors.Keys)
                    {
                        Console.WriteLine($"'{type}'");
                    }
                    continue;
                }
                int? slot = GetSlotChoice();
                if (sensor != null && slot != null)
                {
                    InvestigationRoom.AttachSensor(sensor, (int)slot - 1);
                    InvestigationRoom.DeactivateSensors();
                    InvestigationRoom.ActivateSensors();
                    Console.WriteLine($"Weaknesses found: {InvestigationRoom.GetMatchCount()}/{InvestigationRoom.Agent.Weaknesses.Length}");
                }
                else
                {
                    Console.WriteLine($"Invalid slot! Use number from 1 to {InvestigationRoom.Agent.AttachedSensors.Length}");
                }
                TryAttack();
            }
            if (InvestigationRoom.Agent.IsExposed)
            {
                Console.WriteLine("SUCCESS! Agent exposed!");
                Console.WriteLine($"Mission completed in {turnCount} turns.");
            }
            else
            {
                Console.WriteLine("Game Over - Turn limit reached!");
            }
        }
    }
}
