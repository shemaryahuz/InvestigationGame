# InvestigationGame

A game that simulates interrogating agents using sensors.

---

## Features & Structure

### Project Structure

```
InvestigationGameApp/
├── Core/
│   ├── Game.cs                    # Controls game logic, rules, main loop, and helpers
│   └── InvestigationRoom.cs       # Holds agent, manages sensors, checks against weaknesses
├── Factories/
│   ├── SensorFactory.cs           # Dictionary<string, List<ISensor>>; creates/queries sensors by type
│   └── AgentFactory.cs            # Dictionary<string, List<IAgent>>; creates/queries agents by type
├── Models/
│   ├── Interfaces/
│   │   ├── ISensor.cs             # Sensor interface
│   │   ├── IAgent.cs              # Agent interface
│   │   └── IAttacker.cs           # For agents that can attack (e.g., SquadLeader)
│   ├── Base/
│   │   ├── Sensor.cs              # Abstract base class for sensors
│   │   └── Agent.cs               # Abstract base class for agents
│   ├── Sensors/
│   │   ├── AudioSensor.cs         # Detects audio weaknesses
│   │   ├── ThermalSensor.cs       # Reveals one weakness per use
│   │   └── PulseSensor.cs         # Breaks after 3 uses
│   └── Agents/
│       ├── FootSoldier.cs         # Sample agent implementation
│       └── SquadLeader.cs         # New agent: attacks every 3 turns, has 4 weaknesses, can remove sensors
├── Program.cs                     # Entry point
```

---

## Main Components

### Core

- **Game.cs**: Orchestrates the game, shows rules, runs the main loop, provides helper methods.
- **InvestigationRoom.cs**: Holds an agent, attaches sensors, checks matches to agent’s weaknesses.

### Factories

- **SensorFactory.cs**: Manages a dictionary of sensor types with lists of sensors. Can create new sensors or retrieve by type.
- **AgentFactory.cs**: Manages a dictionary of agent types with lists of agents. Can create or retrieve agents by type.

### Models

#### Interfaces

- **ISensor**: Common sensor contract:
  - `Name`, `Type`, `IsActive`, `Activate()`
- **IAgent**: Common agent contract:
  - `Name`, `Weaknesses`, `AttachedSensors`, `IsExposed`, `AttachSensor(ISensor)`, `GetMatchCount()`
- **IAttacker**: (NEW) Interface for agents that can attack (e.g., SquadLeader), with the `Attack()` method.

#### Base (abstract)

- **Sensor**: Base sensor logic.
- **Agent**: Base agent logic.

#### Sensors

- **AudioSensor**: Matches audio weaknesses.
- **ThermalSensor**: Each use can reveal one agent weakness.
- **PulseSensor**: Breaks and becomes unusable after three uses.

#### Agents

- **FootSoldier**: Example agent with weaknesses.
- **SquadLeader**: (NEW) Can attack every 3 turns, has 4 weaknesses, and removes one attached sensor at random when attacking.

---

## Game Flow & Rules

### Level 1

1. **Start**
   - Game displays intro and rules.
   - Agent is created via `AgentFactory`.
   - Sensors are available via `SensorFactory`.
   - Agent placed in the `InvestigationRoom`.
2. **Game Loop**
   - Each turn: 
     - Shows current status (weaknesses found, sensors used, remaining uses).
     - User chooses a sensor type (Audio, Thermal, Pulse).
     - Sensor is attached and activated on the agent.
     - Shows result (weaknesses found).
     - ThermalSensor finds one weakness per use.
     - PulseSensor breaks after 3 uses.
3. **Game End**
   - Success: All agent weaknesses revealed.
   - Failure: Turn or sensor limit reached.

### Level 2 (NEW)

- **SquadLeader Agent**
  - In addition to the above rules, the SquadLeader attacks every 3 turns.
  - When attacking, the SquadLeader removes (randomly) one attached sensor, making the interrogation harder.
  - The IAttacker interface underlies this attack feature.

### Rules

- Agents have a set of weaknesses (e.g., Audio, Thermal).
- Sensors reveal weaknesses by matching their type.
- **ThermalSensor**: Finds one weakness per use.
- **PulseSensor**: Usable up to 3 times, then breaks.
- **SquadLeader**: Attacks every 3 turns, removing a sensor.
- Goal: Expose all agent weaknesses before you run out of turns or sensors.

---

*This README documents the new structure and game logic on the `additional-agents` branch, including the new SquadLeader agent, attack feature, and core gameplay. More types and features may be added in future updates.*

---

**See all recent changes and code for details:**  
[Commits on additional-agents branch](https://github.com/shemaryahuz/InvestigationGame/commits?sha=additional-agents&per_page=20)vvv