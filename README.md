# InvestigationGame

A game that simulates interrogating agents using sensors.

**Author:** [Shemaryahu Zalmanov](https://github.com/shemaryahuz)

---

## 📁 Project Structure

```
InvestigationGameApp/
├── Controllers/
│   └── GameManager.cs        # Manages all game levels and flow
├── Core/
│   ├── GameLevel.cs          # Encapsulates a single level's logic and state
│   └── InvestigationRoom.cs  # Handles an agent under investigation
├── Factories/
│   ├── AgentFactory.cs       # Static, provides creation of agents for each level
│   └── SensorFactory.cs      # Creates and manages sensors by type
├── Models/
│   ├── Interfaces/
│   │   ├── IAgent.cs         # Agent contract, with GetData() for rules
│   │   └── IAttacker.cs      # For agents that can attack sensors
│   └── ...                   # Agents and sensors implementations
├── UI/
│   ├── Displayer.cs          # All game output and messages
│   └── InputHandler.cs       # All user input and validation
└── Program.cs                # Entry point, initializes and starts the game
```

---

## 🧩 Main Classes & Their Roles

- **Program.cs**  
  Initializes `GameManager` and starts the game by calling `RunAllLevels()`.

- **GameManager.cs**  
  - Controls the flow through all 4 levels.
  - Methods for running each level: Initialize agent (via `AgentFactory`), set turn limit, display level intro, run the level with a loop until win, then show end message.

- **GameLevel.cs**  
  - Properties: Holds the `InvestigationRoom`, its own `SensorFactory`, tracks current turn and turn limit.
  - `GameLoop()` runs turns: displays status, handles user choices, attaches sensors, calls attack logic, checks win/lose.
  - `TryAttack()` allows special agents (those implementing `IAttacker`) to attack at their frequency.

- **Displayer.cs**  
  - Handles all messaging, including start/end screens, turn summaries, agent/sensor rules, and feedback.

- **InputHandler.cs**  
  - Collects and validates all user inputs for sensors and slots.

- **AgentFactory.cs / SensorFactory.cs**  
  - Factories for creating agents (one per level, with increasing complexity) and pools of sensors.

---

## 🎮 Game Flow Overview

```plaintext
┌────────────┐
│ Program.cs │
└─────┬──────┘
      │
      ▼
┌───────────────────────┐
│   GameManager.cs      │
│  RunAllLevels()       │
└───┬───────────────────┘
    │
    ├──▶ Level 1: FootSoldier (2 weaknesses, 10 turns)
    ├──▶ Level 2: SquadLeader (4 weaknesses, 20 turns)
    ├──▶ Level 3: SeniorCommander (6 weaknesses, 30 turns)
    └──▶ Level 4: OrganizationLeader (8 weaknesses, 40 turns)
          (Each: create agent, set turns, run GameLevel)
                 │
                 ▼
       ┌─────────────────┐
       │  GameLevel.cs   │
       │ GameLoop()      │
       └─────┬───────────┘
             │
             ▼
       ┌─────────────────────────────┐
       │ InvestigationRoom,         │
       │ SensorFactory, Displayer,  │
       │ InputHandler               │
       └────────────────────────────┘
```

### Game Loop (per level)
1. **Start:** Show rules and agent data.
2. **Each Turn:**
   - Display status and sensors.
   - User selects sensor and slot.
   - Attach and activate sensor.
   - Agent may attack (if applicable).
   - Show found weaknesses.
3. **End:**
   - Win: All weaknesses exposed.
   - Lose: Turn limit reached.

---

## 🤖 Agent & Sensor Rules

- **Agent rules** (see `IAgent.GetData()`):
  - Each agent has a type and a unique set of weaknesses.
  - Higher levels have agents with more weaknesses and may have attack abilities.
  - Example: OrganizationLeader has 8 weaknesses and attacks sensors every few turns.

- **Sensor rules** (see `Displayer.ShowLevelStart()`):
  - **Audio Sensor:** Records agent's audio.
  - **Thermal Sensor:** Reveals one weakness per turn.
  - **Pulse Sensor:** Breaks after three uses.

---

## 🌟 SOLID Principles in Practice

- **Single Responsibility:**  
  Each class has a clear, focused role (e.g., input, display, game logic, agent creation).

- **Open/Closed:**  
  New agents or sensors can be added by extending factories and interfaces without changing core logic.

- **Liskov Substitution:**  
  All agents and sensors implement interfaces, so game logic works with any conforming type.

- **Interface Segregation:**  
  Separate interfaces for agents, attackers, and sensors (IAgent, IAttacker, ISensor).

- **Dependency Inversion:**  
  High-level modules (`GameManager`, `GameLevel`) interact with abstractions (interfaces, factories), not concrete implementations.

---

## 📝 Summary

- **Levels:** 4, each with a unique agent and increasing difficulty
- **Goal:** Expose all agent weaknesses before the turn limit
- **Gameplay:** Investigate, attach sensors, react to agent attacks, and manage resources to win.

---

**Enjoy your journey into investigation logic and SOLID design!**