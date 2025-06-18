using InvestigationGameApp.Core;
using InvestigationGameApp.Factories;
using InvestigationGameApp.Models.Agents;
using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using InvestigationGameApp.Models.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Core
{
    internal class Game
    {
        private static Game _instance;
        private Game()
        {
            try
            {
                // Create factories
                sensorFactory = SensorFactory.GetInstance();
                agentFactory = AgentFactory.GetInstance();
                // Add agent
                IAgent? agent = agentFactory.GetAgent("footSoldier");
                // Create room
                room = new InvestigationRoom(agent);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static Game GetInstance()
        {
            if (_instance is null)
            {
                _instance = new Game();
            }
            return _instance;
        }
        private InvestigationRoom room;
        private SensorFactory sensorFactory;
        private AgentFactory agentFactory;
        private void StartGame()
        {
            try
            {
                // Show rules
                Console.WriteLine(
                    "=== Investigation Game Started ===\n" +
                    $"Agent {room.Agent.Name} is in the investigation room.\n" +
                    "Your mission: Find all weaknesses to expose the agent!"
                    );
                // Show available sensors with features
                Console.WriteLine("Available sensors with their features:");
                foreach (string type in sensorFactory.Sensors.Keys)
                {
                    Console.WriteLine($"{type} sensors:");
                    foreach (ISensor sensor in sensorFactory.Sensors[type])
                    {
                        Console.WriteLine(sensor.GetData());
                    }
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void ShowStatus()
        {
            try
            {
                // Show match count
                Console.WriteLine(
                    $"Agent {room.Agent.Name}.\n" +
                    $"Weaknesses found: {room.GetMatchCount()}/{room.Agent.Weaknesses.Length}"
                    );
                // Show current attached sensors
                Console.WriteLine("Current sensors:");
                for (int i = 0; i < room.Agent.AttachedSensors.Length; i++)
                {
                    if (room.Agent.AttachedSensors[i] != null)
                    {
                        ISensor slot = room.Agent.AttachedSensors[i];
                        Console.WriteLine($"Slot {i + 1}: {slot.Type} {slot.Name} - Active: {slot.IsActive}");
                    }
                    else
                    {
                        Console.WriteLine($"Slot {i + 1}: Empty");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
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
            Console.WriteLine($"Choose slot to attach in (from 1 to {room.Agent.AttachedSensors.Length})");
            string? slotChoice = Console.ReadLine();
            if ((int.TryParse(slotChoice, out int slot)) && slot >= 1 && slot <= room.Agent.AttachedSensors.Length)
            {
                return slot;
            }
            return null;
        }
        private void GameLoop()
        {
            int turnCount = 0;
            int turnLimit = 10;
            while (!room.Agent.IsExposed && turnCount < turnLimit)
            {
                // Show and increase turn count
                turnCount++;
                Console.WriteLine($"=== Turn {turnCount} ===");
                Console.WriteLine($"=== {turnLimit - turnCount} Turns left ===");
                ShowStatus();
                ISensor sensor = null;
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
                    room.AttachSensor(sensor, (int)slot - 1);
                    room.DeactivateSensors();
                    room.ActivateSensors();
                    Console.WriteLine($"Weaknesses found: {room.GetMatchCount()}/{room.Agent.Weaknesses.Length}");
                }
                else
                {
                    Console.WriteLine($"Invalid slot! Use number from 1 to {room.Agent.AttachedSensors.Length}");
                }
            }
            if (room.Agent.IsExposed)
            {
                Console.WriteLine("SUCCESS! Agent exposed!");
                Console.WriteLine($"Mission completed in {turnCount} turns.");
            }
            else
            {
                Console.WriteLine("Game Over - Turn limit reached!");
            }
        }
        public void Run()
        {
            StartGame();
            GameLoop();
        }
    }
}
