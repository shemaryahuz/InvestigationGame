using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Base
{
    internal class AgentBase: IAgent
    {
        public string Name { get; set; }
        public string[] Weaknesses { get; set; }
        public List<ISensor> AttachedSensors { get; set; }
        public bool IsExposed { get; set; }
        public void AttachSensor(ISensor sensor)
        {
            AttachedSensors.Add(sensor);
        }
        public int GetMatchCount()
        {
            int matchCount = 0;
            return matchCount;
        }
    }
}
