using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Models.Base
{
    internal class SensorBase: ISensor
    {
        public string Name { get; set; }
        public virtual string Type { get; set; } = "Basic";
        public bool IsActive { get; set; }
        public void Activate() { }
    }
}
