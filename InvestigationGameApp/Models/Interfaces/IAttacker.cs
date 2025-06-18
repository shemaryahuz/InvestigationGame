using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Interfaces
{
    internal interface IAttacker
    {
        bool HasSensors { get; set; }
        int AttackFrequency { get; set; }
        void Attack();
    }
}
