using InvestigationGameApp.Models.Agents;
using InvestigationGameApp.Models.Base;
using InvestigationGameApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Factories
{
    internal static class AgentFactory
    {
        public static FootSoldier CreateFootSoldier()
        {
            int weaknessesLength = 2;
            string[] weaknesses = GetRandomWeaknesses(weaknessesLength, GetSensorTypes());
            return new FootSoldier(weaknesses);
        }
        public static SquadLeader CreateSquadLeader()
        {
            int weaknessesLength = 4;
            string[] weaknesses = GetRandomWeaknesses(weaknessesLength, GetSensorTypes());
            return new SquadLeader(weaknesses);
        }
        public static SeniorCommander CreateSeniorCommander()
        {
            int weaknessesLength = 6;
            string[] weaknesses = GetRandomWeaknesses(weaknessesLength, GetSensorTypes());
            return new SeniorCommander(weaknesses);
        }
        public static OrganizationLeader CreateOrganizationLeader()
        {
            int weaknessesLength = 8;
            string[] weaknesses = GetRandomWeaknesses(weaknessesLength, GetSensorTypes());
            return new OrganizationLeader(weaknesses);
        }
        private static string[] GetSensorTypes()
        {
            List<string> types = new List<string>();
            SensorFactory sensorFactory = SensorFactory.GetInstance();
            foreach (string sensorType in sensorFactory.Sensors.Keys)
            {
                types.Add(sensorType);
            }
            return types.ToArray();
        }
        private static string[] GetRandomWeaknesses(int length, string[] types)
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
