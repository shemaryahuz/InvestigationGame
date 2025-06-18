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
            CreateFootSoldiers();
            CreateSquadLeaders();
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
            ["footSoldier"] = new List<IAgent>(),
            ["squadLeader"] = new List<IAgent>()
        };
        public void CreateFootSoldiers()
        {
            int weaknessesLength = 2;
            for (int i = 0; i < 5; i++)
            {
                string[] types = GetSensorTypes();
                string[] weaknesses = GetRandomWeaknesses(weaknessesLength, types);
                FootSoldier footSoldier = new FootSoldier($"footSoldier{DateTime.Now.Millisecond}", weaknesses);
                Agents["footSoldier"].Add(footSoldier);
            }
        }
        public void CreateSquadLeaders()
        {
            int weaknessesLength = 4;
            for (int i = 0; i < 5; i++)
            {
                string[] types = GetSensorTypes();
                string[] weaknesses = GetRandomWeaknesses(weaknessesLength, types);
                SquadLeader squadLeader = new SquadLeader($"squadLeader{DateTime.Now.Millisecond}", weaknesses);
                Agents["squadLeader"].Add(squadLeader);
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
        private string[] GetRandomWeaknesses(int length, string[] types)
        {
            string[] weaknesses = new string[length];
            // Add random weaknesses from sensorTypes
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(types.Length);
                weaknesses[i] = types[randomIndex];
            }
            return weaknesses;
        }
    }
}
