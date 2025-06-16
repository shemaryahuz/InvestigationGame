# InvestigationGame

A game that simulates interrogating agents using sensors

---

# Investigation Game - Basic Feature

## Project Structure

```
InvestigationGameApp/
├── Controllers/
│   └── GameController.cs         # Main game loop and logic
├── Models/
│   ├── Agents/
│   │   └── FootAgent.cs         # Example implementation of an agent
│   ├── Sensors/
│   │   ├── AudioSensor.cs       # Implements ISensor for audio
│   │   └── ThermalSensor.cs     # Implements ISensor for thermal
│   ├── Interfaces/
│   │   ├── IAgent.cs            # Agent interface
│   │   └── ISensor.cs           # Sensor interface
│   ├── Base/
│   │   └── Agent.cs             # Base agent class
│   └── InvestigationRoom.cs     # Represents the room with agent and sensors
├── Program.cs                   # Entry point
```

## Implemented Classes and Interfaces

### ISensor (interface)
Defines the contract for sensors:
- `Name` (string)
- `Type` (string)
- `IsActive` (bool)
- `Activate()`

### IAgent (interface)
Defines the contract for agents:
- `Name` (string)
- `Weaknesses` (string[])
- `AttachedSensors` (list/array of ISensor)
- `IsExposed` (bool)
- `AttachSensor(ISensor sensor)`
- `GetMatchCount()`

### AudioSensor (class)
Implements ISensor for audio detection.

### ThermalSensor (class)
Implements ISensor for thermal detection.

### Agent (class)
Implements IAgent, tracks weaknesses and attached sensors.

### InvestigationRoom (class)
Holds the agent and available sensors.

### GameController (class)
Handles game setup, main loop, and user interaction:
- `StartGame()`: Initializes agent and room, prints intro.
- `GameLoop()`: Handles each turn until agent is exposed or turns run out.
- `CreateSensor(type)`: Instantiates the correct sensor.
- `ShowStatus()`: Prints current state each turn.
- `Run()`: Entry for controller (calls StartGame and GameLoop).

## Program Flow

1. **Entry Point (`Program.cs`):**
   - Instantiates `GameController` and calls `Run()`.

2. **Start Game (`GameController.cs`):**
   - Creates an agent (e.g., `FootAgent`) with random weaknesses.
   - Puts agent in `InvestigationRoom`.
   - Prints welcome, rules, and available sensors.

3. **Game Loop:**
   - For up to 10 turns, or until all agent weaknesses are found:
     - Shows current state (weaknesses found, sensors attached).
     - Prompts user to choose sensor type (`audio` or `thermal`).
     - Creates and attaches the selected sensor to the agent.
     - Activates the sensor and checks for matches.
     - Prints result ("X/2 weaknesses found").
     - If an invalid sensor type is entered, prompts again.

4. **End Game:**
   - If all weaknesses are found: prints success and turn count.
   - If turn limit reached: prints game over.

## Basic Rules

- Agent has 2 weaknesses (randomly chosen from Audio, Thermal).
- Each turn, user selects a sensor to try to expose weaknesses.
- Win by finding both weaknesses before running out of turns.

---

*For future features, more agent/sensor types and deeper mechanics may be added. This README covers only the currently implemented logic and structure.*