using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models
{
    internal class InvestigationRoom
    {
        public int ID { get; set; }
        public IAgent Agent { get; set; }
        public string[] AvailableSensors { get; set; } = { "Basic", "Audio", "Thermal" };
    }
}
