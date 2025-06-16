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

            // Show rules
            Console.WriteLine(
                "=== Investigation Game Started ===\n" +
                $"Agent {agent.Name} is in the investigation room.\n" +
                "Your mission: Find all weaknesses to expose the agent!"
                );
            // Show available sensors
            Console.Write("Available sensors:");
            foreach (string sensor in room.AvailableSensors)
            {
                Console.Write($" {sensor}");
            }
            Console.WriteLine();
        }
        private void ShowStatus()
        {
            if (room?.Agent != null)
            {
                // Show match count
                Console.WriteLine(
                    $"Agent {room.Agent.Name}.\n" +
                    $"Weaknesses found: {room.Agent.GetMatchCount()}/{room.Agent.Weaknesses.Length}"
                    );
                // Show current attached sensors
                Console.WriteLine("Current sensors:");
                for (int i = 0; i < room.Agent.AttachedSensors.Length; i++)
                {
                    if (room.Agent.AttachedSensors[i] != null)
                    {
                        ISensor slot = room.Agent.AttachedSensors[i];
                        Console.WriteLine($"Slot {i + 1}: {slot.Type} - Active: {slot.IsActive}");
                    }
                    else
                    {
                        Console.WriteLine($"Slot {i + 1}: Empty");
                    }
                }
            }
        }
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
        private void GameLoop()
        {
            int turnCount = 0;
            int turnLimit = 10;
            while (room.Agent.GetMatchCount() < room.Agent.Weaknesses.Length && turnCount <= turnLimit)
            {
                // Show and increase turn count
                turnCount++;
                Console.WriteLine($"=== Turn {turnCount} ===");
                ShowStatus();
                // Get choice
                Console.WriteLine("Choose sensor type ('audio' or 'thermal'):");
                string input = Console.ReadLine()?.ToLower();
                // Create sensor
                ISensor? sensor = CreateSensor(input);
                if (sensor != null)
                {
                    room.Agent.AttachSensor(sensor);
                    sensor.Activate();
                    Console.WriteLine(
                        $"Sensor {sensor.Name} activated!\n" +
                        $"Weaknesses found: {room.Agent.GetMatchCount()}/{room.Agent.Weaknesses.Length}"
                        );
                }
                else
                {
                    Console.WriteLine("Invalid sensor type! Use 'audio' or 'thermal'");
                }
            }
            if (room.Agent.GetMatchCount() < room.Agent.Weaknesses.Length)
            {
                Console.WriteLine("Game Over - Turn limit reached!");
            }
            else
            {
                Console.WriteLine("SUCCESS! Agent exposed!");
                Console.WriteLine($"Mission completed in {turnCount} turns.");
            }
        }
        public void Run()
        {
            StartGame();
            GameLoop();
        }
    }
}
