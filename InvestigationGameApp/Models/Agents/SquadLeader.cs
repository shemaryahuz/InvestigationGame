using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Agents
{
    // Class that represents SquadLeader, has 4 weaknesses and attacks every 3 turns
    internal class SquadLeader : Agent, IAgent, IAttacker
    {
        private const int weaknessesLength = 4;
        public SquadLeader(string name, string[] weaknesses)
            : base(name, weaknesses, weaknessesLength) { }
        public bool HasSensors { get; set; } = false;
        public int AttackFrequency { get; set; } = 3;
        public void Attack()
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
                            $"Squad leader {Name} removed Sensor {AttachedSensors[randomIndex].Type} {AttachedSensors[randomIndex].Name}!\n" +
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
