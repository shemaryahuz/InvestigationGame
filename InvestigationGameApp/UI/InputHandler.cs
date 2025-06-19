using InvestigationGameApp.Core;
using InvestigationGameApp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.UI
{
    internal static class InputHandler
    {
        public static string? GetSensorChoice(SensorFactory sensorFactory)
        {
            // Get sensor choice
            Console.WriteLine("Choose sensor type from the fallowing:");
            foreach (string type in sensorFactory.Sensors.Keys)
            {
                Console.WriteLine($"'{type}'");
            }
            string? sensorChoice = Console.ReadLine()?.ToLower();
            Console.WriteLine("\n");
            return sensorChoice;
        }
        public static bool ValidateSensorChoice(string? sensorChoice, SensorFactory sensorFactory)
        {
            return sensorChoice != null && sensorFactory.Sensors.ContainsKey(sensorChoice);
        }
        public static void InvalidSensorMessage(SensorFactory sensorFactory)
        {
            Console.WriteLine("Invalid sensor type! Use one of the fallowing:");
            foreach (string type in sensorFactory.Sensors.Keys)
            {
                Console.WriteLine($"'{type}'");
            }
            Console.WriteLine("\n");
        }
        public static int? GetSlotChoice(InvestigationRoom room)
        {
            // Get slot choice
            Console.WriteLine($"Choose slot to attach in (from 1 to {room.Agent.AttachedSensors.Length})");
            string? slotChoice = Console.ReadLine();
            Console.WriteLine("\n");
            if ((int.TryParse(slotChoice, out int slot)) && slot >= 1 && slot <= room.Agent.AttachedSensors.Length)
            {
                return slot;
            }
            return null;
        }
        public static void InvalidSlotMessage(InvestigationRoom room)
        {
            Console.WriteLine($"Invalid slot! Use number from 1 to {room.Agent.AttachedSensors.Length}\n");
        }
    }
}
