using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Interfaces
{
    internal interface IAttacker
    {
        int AttackCounter { get; set; }
        void Attack();
    }
}
