using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Agents
{
    internal class OrganizationLeader : Agent, IAttacker
    {
        private const int weaknessesLength = 8;
        public OrganizationLeader(string name, string[] weaknesses)
            : base(name, weaknesses, weaknessesLength) { }
        public bool HasSensors { get; set; } = false;
        public int AttackFrequency { get; set; } = 3;
        public void Attack()
        {
            if (HasSensors)
            {
                for (int i = 0; i < AttachedSensors.Length; i++)
                {
                    if (AttachedSensors[i] != null)
                    {
                        Console.WriteLine(
                                $"Senior Commander {Name} removed Sensor {AttachedSensors[i].Type} {AttachedSensors[i].Name}!\n" +
                                $"Slot {i + 1} is empty."
                                );
                        AttachedSensors[i] = null!;
                    }
                }
            }
        }
    }
}
