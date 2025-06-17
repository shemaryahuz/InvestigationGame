using InvestigationGameApp.Models.Agents;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Factories
{
    internal class AgentFactory
    {
        private static AgentFactory _instance;
        private AgentFactory()
        {
            CreateAgents();
        }
        public static AgentFactory GetInstance()
        {
            if (_instance is null)
            {
                _instance = new AgentFactory();
            }
            return _instance;
        }
        public Dictionary<string, List<IAgent>> Agents { get; set; } = new Dictionary<string, List<IAgent>>
        {
            ["footSoldier"] = new List<IAgent>()
        };
        public void CreateAgents()
        {
            // Add foot soldiers
            for (int i = 0; i < 5; i++)
            {
                string[] types = GetSensorTypes();
                string[] weaknesses = GetRandomWeaknesses(2, types);
                FootSoldier footSoldier = new FootSoldier($"footSoldier{DateTime.Now.Millisecond}", weaknesses);
                Agents["footSoldier"].Add(footSoldier);
            }
        }
        public IAgent? GetAgent(string agentType)
        {
            IAgent agent = null;
            foreach (IAgent a in Agents[agentType])
            {
                if (!a.IsExposed)
                {
                    agent = a;
                    break;
                }
            }
            return agent;
        }
        private string[] GetSensorTypes()
        {
            List<string> types = new List<string>();
            SensorFactory sensorFactory = SensorFactory.GetInstance();
            foreach (string sensorType in sensorFactory.Sensors.Keys)
            {
                types.Add(sensorType);
            }
            return types.ToArray();
        }
        private string[] GetRandomWeaknesses(int amount, string[] types)
        {
            string[] weaknesses = new string[amount];
            // Add random weaknesses from sensorTypes
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                int randomIndex = random.Next(types.Length);
                weaknesses[i] = types[randomIndex];
            }
            return weaknesses;
        }
    }
}
