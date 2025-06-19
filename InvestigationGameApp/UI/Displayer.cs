using InvestigationGameApp.Core;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.UI
{
    internal static class Displayer
    {
        public static void ShowGameStart()
        {
            Console.WriteLine(
                "==== Welcome to the Investigation Game ====\n" +
                "The Game simulates investigation of agents using sensors.\n" +
                "Ones you have exposed agent you will go to the next level.\n\n"
                );
        }
        public static void ShowLevelStart(IAgent agent, int levelNumber, int turnsLimit)
        {
            // Show rules
            Console.WriteLine(
                $"=== Level {levelNumber} ===\n\n" +
                $"Agent {agent.Type} is in the investigation room.\n" +
                "Your mission: Find all weaknesses to expose the agent!\n\n"
                );
        }
        public static void ShowRules(InvestigationRoom room)
        {
            Console.WriteLine("Rules and features:\n");
            // Show agent data
            Console.WriteLine("Agent data:");
            Console.WriteLine($"{room.Agent.GetData()}\n");
            // Show available sensors with features
            Console.WriteLine(
                "Sensors types with their features:\n" +
                "Audio Sensor: recording agent's audio.\n" +
                "Thermal Sensor: checking agent's temperature and reveals one weakness every turn.\n" +
                "Pulse Sensor: checking agent's heart rate and broke after three uses.\n\n\n"
                );
        }
        public static void ShowTurn(int turn, int limit)
        {
            Console.WriteLine($"=== Turn {turn} ===");
            Console.WriteLine($"=== {limit - turn} Turns left ===\n\n");
        }
        public static void ShowStatus(InvestigationRoom room)
        {
            // Show match count
            Displayer.ShowFoundWeaknesses(room);
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
            Console.WriteLine("\n");
        }
        public static void ShowFoundWeaknesses(InvestigationRoom room)
        {
            Console.WriteLine(
                $"Agent {room.Agent.Type}.\n" +
                $"Weaknesses found: {room.GetMatchCount()}/{room.Agent.Weaknesses.Length}"
                );
        }
        public static void ShowWin(int turn)
        {
            Console.WriteLine("SUCCESS! Agent exposed!");
            Console.WriteLine($"Mission completed in {turn} turns.\n\n");
        }
        public static void ShowLose()
        {
            Console.WriteLine("Game Over - Turn limit reached!\n\n");
        }
        public static void ShowEndGame()
        {
            Console.WriteLine(
                "CONGRATULATIONS!!!\n" +
                " You have revealed all the agents!!\n" +
                " Thank you for using the investigation game, we look forward to seeing you again!"
                );
        }
    }
}
