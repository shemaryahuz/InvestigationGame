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
            CreateFootSoldier();
            CreateSquadLeader();
            CreateSeniorCommander();
            CreateOrganizationLeader();
        }
        public static AgentFactory GetInstance()
        {
            if (_instance is null)
            {
                _instance = new AgentFactory();
            }
            return _instance;
        }
        public Dictionary<string, IAgent> Agents { get; set; } = new Dictionary<string, IAgent > ();
        public void CreateFootSoldier()
        {
            int weaknessesLength = 2;
            string[] weaknesses = GetRandomWeaknesses(weaknessesLength, GetSensorTypes());
            Agents["Foot Soldier"] = new FootSoldier(weaknesses);
        }
        public void CreateSquadLeader()
        {
            int weaknessesLength = 4;
            string[] weaknesses = GetRandomWeaknesses(weaknessesLength, GetSensorTypes());
            Agents["Squad Leader"] = new SquadLeader(weaknesses);
        }
        public void CreateSeniorCommander()
        {
            int weaknessesLength = 6;
            string[] weaknesses = GetRandomWeaknesses(weaknessesLength, GetSensorTypes());
            Agents["Senior Commander"] = new SeniorCommander(weaknesses);
        }
        public void CreateOrganizationLeader()
        {
            int weaknessesLength = 8;
            string[] weaknesses = GetRandomWeaknesses(weaknessesLength, GetSensorTypes());
            Agents["Organization Leader"] = new OrganizationLeader(weaknesses);
        }
        public IAgent? GetAgent(string agentType)
        {
            if (Agents.ContainsKey(agentType))
            {
                return Agents[agentType];
            }
            return null;
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
