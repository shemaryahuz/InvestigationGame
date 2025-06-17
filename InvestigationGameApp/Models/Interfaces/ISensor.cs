using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Interfaces
{
    // interface for contract of all sensors
    internal interface ISensor
    {
        string Name { get; }
        string Type { get; }
        IAgent Target { get; set; }
        bool IsActive { get; set; }
        void Activate();
        void Deactivate();
        string GetData();
    }
}
