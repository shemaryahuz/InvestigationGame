using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Interfaces
{
    internal interface IAgent
    {
        string Name { get; }
        string[] Weaknesses { get; }
        List<ISensor> AttachedSensors { get; }
        bool IsExposed { get; }
        void AttachSensor(ISensor sensor);
        int GetMatchCount();
    }
}
