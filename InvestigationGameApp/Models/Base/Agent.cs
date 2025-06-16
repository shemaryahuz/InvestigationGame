using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Base
{
    internal class Agent: IAgent
    {
        public Agent(string name)
        {
            this.Name = name;
            this.IsExposed = false;
        }
        public string Name { get; }
        public string[] Weaknesses { get; set; }
        public ISensor[] AttachedSensors { get; set; }
        public bool IsExposed { get; set; }
        public void AttachSensor(ISensor sensor) { }
        public int GetMatchCount()
        {
            int matchCount = 0;
            return matchCount;
        }
    }
}
