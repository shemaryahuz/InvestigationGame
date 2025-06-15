# InvestigationGame
A game that simulates interrogating agents using sensors
---
# Investigation Game - Basic Feature

## Project Structure
```
InvestigationGame/
├── Models/
│   ├── ISensor.cs
│   ├── IAgent.cs
│   ├── AudioSensor.cs
│   ├── ThermalSensor.cs
│   ├── Agent.cs
│   └── InvestigationRoom.cs
├── GameController.cs
└── Program.cs
```

## Class Templates

### ISensor.cs
```csharp
interface ISensor
{
    string Name { get; }
    string Type { get; }
    bool IsActive { get; set; }
    void Activate();
}
```

### IAgent.cs
```csharp
interface IAgent
{
    string Name { get; }
    string[] Weaknesses { get; }
    List<ISensor> AttachedSensors { get; }
    bool IsExposed { get; }
    void AttachSensor(ISensor sensor);
    int GetMatchCount();
}
```

### AudioSensor.cs
```csharp
class AudioSensor : ISensor
{
    public string Name { get; set; }
    public string Type { get; set; } = "Audio";
    public bool IsActive { get; set; }
    public void Activate() { /* implementation */ }
}
```

### ThermalSensor.cs
```csharp
class ThermalSensor : ISensor
{
    public string Name { get; set; }
    public string Type { get; set; } = "Thermal";
    public bool IsActive { get; set; }
    public void Activate() { /* implementation */ }
}
```

### Agent.cs
```csharp
class Agent : IAgent
{
    public string Name { get; set; }
    public string[] Weaknesses { get; set; }
    public List<ISensor> AttachedSensors { get; set; }
    public bool IsExposed { get; set; }
    
    public void AttachSensor(ISensor sensor) { /* implementation */ }
    public int GetMatchCount() { /* implementation */ }
}
```

### InvestigationRoom.cs
```csharp
class InvestigationRoom
{
    public int ID { get; set; }
    public IAgent Agent { get; set; }
    public string[] AvailableSensors { get; set; } = { "Audio", "Thermal" };
}
```

### GameController.cs
```csharp
class GameController
{
    private InvestigationRoom room;
    
    public void StartGame() { /* implementation */ }
    public void GameLoop() { /* implementation */ }
    public ISensor CreateSensor(string type) { /* implementation */ }
    public void ShowStatus() { /* implementation */ }
}
```

## Program Flow

1. **Initialize**
   - Create agent with 2 random weaknesses
   - Create investigation room
   - Show welcome message

2. **Game Loop**
   ```
   WHILE not agent.IsExposed:
       - Show sensor options (Audio, Thermal)
       - Get user choice
       - Create and attach sensor
       - Activate sensor
       - Show result: "X/2 weaknesses found"
   ```

3. **End Game**
   - Show "Agent exposed!" message
   - Display turns used

## Basic Rules
- Agent has 2 weaknesses from: Audio, Thermal
- Each turn: choose sensor → attach → activate → check match
- Win when all weaknesses found
