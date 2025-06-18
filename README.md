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
│   ├── SensorFactory.cs           # Creates and stores 5 sensors from all types
│   └── AgentFactory.cs            # Creates and stores one agent from all types
├── Models/
│   ├── Interfaces/
│   │   ├── ISensor.cs             # Sensor interface
│   │   ├── IAgent.cs              # Agent interface
│   │   └── IAttacker.cs           # For agents that can attack
│   ├── Base/
│   │   ├── Sensor.cs              # Abstract base class for sensors
│   │   └── Agent.cs               # Abstract base class for agents
│   ├── Sensors/
│   │   ├── AudioSensor.cs
│   │   ├── ThermalSensor.cs
│   │   └── PulseSensor.cs
│   └── Agents/
│       ├── FootSoldier.cs
│       └── SquadLeader.cs
├── Program.cs                     # Entry point
```

---

## Main Components & Flow (Branch: `fix-factories`)

### SensorFactory.cs
- Creates and stores 5 sensors from all types.

### AgentFactory.cs
- Creates and stores one agent from all types.

### InvestigationRoom.cs
- Contains the current agent.
- Methods to attach sensors, check for matches, and expose the agent.
- Supports deactivating and activating sensors (e.g., for breaking sensors).

### Game.cs
- **Fields:** `room`, `agentFactory`, `sensorFactory`, `turnCount` (starts at 0), `turnLimit` (10 by default).
- **Constructor:**
  - Receives an agent type string.
  - Creates factories and the agent (using `getAgent` by type from `agentFactory`).
  - Creates the room with the agent.
- **startGame():** Displays details and rules.
- **showStatus():** Shows current status of the investigation via the room.
- **GetSensorChoice()/GetSlotChoice():** Get user choices for sensors and slots.
- **TryAttack():** If the agent is an attacker (implements `IAttacker`), and turn count is at the appropriate interval, performs an attack action.
- **gameLoop():**
  - While the agent is not exposed and turn limit is not reached:
    - Show status.
    - Get user choices.
    - Attach sensor.
    - Deactivate sensors if needed (e.g., for breaking sensors).
    - Activate sensors.
    - Show the result.
  - At loop end, shows win or lose message.
- **Run():**
  - Calls `startGame()` and `gameLoop()`.

### Program.cs
- Creates a `Game` object and runs it 4 times for 4 levels, each with the next agent type.

---

## Gameplay Overview

1. **Start the Game:**  
   - Rules and details are displayed.
   - Agent and sensor factories are set up.
   - The chosen agent is placed in the investigation room.

2. **Game Loop (up to 10 turns):**
   - The current status is shown.
   - User chooses a sensor and slot.
   - Sensor is attached to the agent.
   - Sensors can be deactivated/reactivated (for breaking and attack features).
   - If the agent is an attacker and it's time, an attack may occur (e.g., removing a sensor).
   - Results are displayed.

3. **End Game:**  
   - If the agent is exposed (all weaknesses found), you win.
   - If the turn limit is reached without exposing the agent, you lose.

---

## Rules & Features

- **Agents** have specific weaknesses.
- **Sensors** are used to expose agent weaknesses.
- **ThermalSensor**: Reveals one weakness per use.
- **PulseSensor**: Breaks after 3 uses.
- **SquadLeader** (attacker): Every 3 turns, can remove one attached sensor.
- **Win Condition:** Expose all agent weaknesses before reaching turn limit.

---

**This README describes the new project flow as implemented on the `fix-factories` branch. For more details, see the code and commit history.**