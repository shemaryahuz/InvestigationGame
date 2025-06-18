using InvestigationGameApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.UI
{
    internal static class Displayer
    {
        public static void ShowRules(InvestigationRoom room)
        {
            // Show rules
            Console.WriteLine(
                "=== Investigation Game Started ===\n\n" +
                $"Agent {room.Agent.Type} is in the investigation room.\n" +
                "Your mission: Find all weaknesses to expose the agent!\n\n"
                );
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
            Console.WriteLine($"=== {limit - turn} Turns left ===");
        }
    }
}
