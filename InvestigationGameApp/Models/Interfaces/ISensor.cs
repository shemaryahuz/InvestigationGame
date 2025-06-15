using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Interfaces
{
    internal interface ISensor
    {
        string Name { get; }
        string Type { get; }
        bool IsActive { get; set; }
        void Activate();
    }
}
