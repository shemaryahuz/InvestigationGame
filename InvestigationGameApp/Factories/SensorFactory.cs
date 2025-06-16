using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGameApp.Models.Interfaces;

namespace InvestigationGameApp.Factories
{
    internal class SensorFactory
    {
        public List<ISensor> Sensors = new List<ISensor>();
    }
}
