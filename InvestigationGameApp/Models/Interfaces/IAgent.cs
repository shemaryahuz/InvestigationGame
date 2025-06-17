using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Interfaces
{
    // interface for contract of all agents
    internal interface IAgent
    {
        string Name { get; }
        string[] Weaknesses { get; set; }
        ISensor[] AttachedSensors { get; }
        bool IsExposed { get; set; }
    }
}
