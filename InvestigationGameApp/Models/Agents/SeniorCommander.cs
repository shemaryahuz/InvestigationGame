using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Agents
{
    internal class SeniorCommander : Agent, IAgent, IAttacker
    {
        private const int weaknessesLength = 6;
        public SeniorCommander(string name, string[] weaknesses)
            : base(name, weaknesses, weaknessesLength) { }
        public bool HasSensors { get; set; } = false;
        public int AttackFrequency { get; set; } = 3;
        public void Attack()
        {
            for (int i = 0; i < 2; i++)
            {
                if (HasSensors)
                {
                    Random random = new Random();
                    bool removed = false;
                    while (!removed)
                    {
                        int randomIndex = random.Next(AttachedSensors.Length);
                        if (AttachedSensors[randomIndex] != null)
                        {
                            Console.WriteLine(
                                $"Senior Commander {Name} removed Sensor {AttachedSensors[randomIndex].Type} {AttachedSensors[randomIndex].Name}!\n" +
                                $"Slot {randomIndex + 1} is empty."
                                );
                            AttachedSensors[randomIndex] = null!;
                            removed = true;
                        }
                    }
                }
            }
        }
    }
}
