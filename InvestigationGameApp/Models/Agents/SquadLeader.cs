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
        public int AttackCounter { get; set; } = 0;
        public void Attack()
        {
            if (AttackCounter == 3)
            {
                Random random = new Random();
                int randomIndex = random.Next(AttachedSensors.Length);
                AttachedSensors[randomIndex] = null!;
            }
        }
    }
}
