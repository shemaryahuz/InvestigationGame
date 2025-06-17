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

namespace InvestigationGameApp.Controllers
{
    internal class GameController
    {
        private static GameController _instance;
        private GameController()
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
        public static GameController GetInstance()
        {
            if (_instance is null)
            {
                _instance = new GameController();
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
                // Show available sensors
                Console.WriteLine("Available sensors:");
                foreach (string type in sensorFactory.Sensors.Keys)
                {
                    Console.WriteLine($"{type} sensors:");
                    foreach (ISensor sensor in sensorFactory.Sensors[type])
                    {
                        Console.WriteLine($"{sensor.Type} {sensor.Name}");
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
        private void GameLoop()
        {
            int turnCount = 0;
            int turnLimit = 10;
            try
            {
                while (!room.Agent.IsExposed && turnCount < turnLimit)
                {
                    // Show and increase turn count
                    turnCount++;
                    Console.WriteLine($"=== Turn {turnCount} ===");
                    Console.WriteLine($"=== {turnLimit - turnCount} Turns left ===");
                    ShowStatus();
                    // Get choice
                    Console.WriteLine("Choose sensor type ('audio' or 'thermal'):");
                    string input = Console.ReadLine()?.ToLower();
                    // Create sensor
                    ISensor? sensor = sensorFactory.GetSensor(input);
                    if (sensor != null)
                    {
                        room.AttachSensor(sensor);
                        room.ActivateSensors();
                        Console.WriteLine($"Weaknesses found: {room.GetMatchCount()}/{room.Agent.Weaknesses.Length}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid sensor type! Use 'audio' or 'thermal'");
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
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void Run()
        {
            StartGame();
            GameLoop();
        }
    }
}
