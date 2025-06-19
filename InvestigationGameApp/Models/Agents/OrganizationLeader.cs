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
        public OrganizationLeader(string[] weaknesses)
            : base("Organization Leader", weaknesses, weaknessesLength) { }
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
                                $"{Type} removed Sensor {AttachedSensors[i].Type} {AttachedSensors[i].Name}!\n" +
                                $"Slot {i + 1} is empty."
                                );
                        AttachedSensors[i] = null!;
                    }
                }
            }
        }
        public override string GetData()
        {
            return $"{base.GetData()} Feature: removes one sensor every 3 turns.";
        }
    }
}
