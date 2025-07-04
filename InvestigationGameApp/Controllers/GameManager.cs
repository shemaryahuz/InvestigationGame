﻿using InvestigationGameApp.Core;
using InvestigationGameApp.Factories;
using InvestigationGameApp.Models.Interfaces;
using InvestigationGameApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameApp.Controllers
{
    internal class GameManager
    {
        private GameLevel level;
        private int levelNumber;
        private int levelLimit;
        private IAgent agent;
        private int sensorsQuantity;
        private bool win = false;
        public void RunAllLevels()
        {
            Displayer.ShowGameStart();
            RunLevel1();
            RunLevel2();
            RunLevel3();
            RunLevel4();
            Displayer.ShowEndGame();
        }
        private void RunLevel(GameLevel level)
        {
            win = false;
            while (!win)
            {
                win = GameRunner.Run(level);
            }
        }
        public void RunLevel1()
        {
            levelNumber = 1;
            agent = AgentFactory.CreateFootSoldier();
            sensorsQuantity = 5;
            levelLimit = 10;
            level = new GameLevel(agent, levelLimit, sensorsQuantity);
            Displayer.ShowLevelStart(agent, levelNumber, levelLimit);
            RunLevel(level);
        }
        public void RunLevel2()
        {
            levelNumber = 2;
            agent = AgentFactory.CreateSquadLeader();
            sensorsQuantity = 10;
            levelLimit = 20;
            level = new GameLevel(agent, levelLimit, sensorsQuantity);
            Displayer.ShowLevelStart(agent, levelNumber, levelLimit);
            RunLevel(level);
        }
        public void RunLevel3()
        {
            levelNumber = 3;
            agent = AgentFactory.CreateSeniorCommander();
            sensorsQuantity = 15;
            levelLimit = 30;
            level = new GameLevel(agent, levelLimit, sensorsQuantity);
            Displayer.ShowLevelStart(agent, levelNumber, levelLimit);
            RunLevel(level);
        }
        public void RunLevel4()
        {
            levelNumber = 4;
            agent = AgentFactory.CreateOrganizationLeader();
            sensorsQuantity = 20;
            levelLimit = 40;
            level = new GameLevel(agent, levelLimit, sensorsQuantity);
            Displayer.ShowLevelStart(agent, levelNumber, levelLimit);
            RunLevel(level);
        }
    }
}
