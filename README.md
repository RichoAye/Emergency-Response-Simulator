# Rahel Mekonen ID=1501427

# Emergency Response Simulation

This C# program simulates a basic emergency response system where various emergency units (e.g., Police, Firefighters, Ambulance, SWAT, etc.) respond to incidents. The system uses object-oriented programming (OOP) concepts such as abstraction, inheritance, and polymorphism to model different emergency units and their specific behaviors.

## Key Components

### EmergencyUnit (Abstract Class)
- **Name**: The name of the emergency unit.
- **Speed**: The speed of the unit (used to simulate response time).
- **Abstract Methods**:
  - `CanHandle(string incidentType)`: Determines if the unit can handle a specific type of incident.
  - `RespondToIncident(Incident incident)`: Defines how the unit responds to an incident.

### Incident Class
- **Type**: The type of incident (e.g., Crime, Fire, Medical).
- **Location**: The location where the incident occurs.
- **Difficulty**: The difficulty level of the incident (1 to 10).

### Specialized Emergency Units
- **Police**, **Firefighter**, **Ambulance**, **SWAT**, **SearchAndRescue**, **Hazmat**
  - These classes inherit from `EmergencyUnit` and override the `CanHandle()` and `RespondToIncident()` methods to implement specific behaviors for different incident types.

### Program (Main Simulation Logic)
- A list of emergency units is initialized with different names and speeds.
- Random incidents (including type, location, and difficulty) are generated each turn.
- The user can manually select an emergency unit or let the system choose one automatically.
- The selected unit’s ability to handle the incident is checked. If it can handle it, the unit responds, and points are awarded based on the difficulty and response time. If it cannot handle the incident, points are deducted.
- The game runs for 5 turns and tracks the total score.

## Features
- **Manual vs Automatic Unit Selection**: Choose to manually select an emergency unit or have one selected automatically.
- **Score Calculation**: Points are awarded based on unit performance (response time and incident difficulty), with penalties for units that cannot handle the incident.
- **Simulation Turns**: The simulation runs for 5 turns with random incidents and updates the score.

## OOP Concepts Demonstrated
- **Abstraction**: The `EmergencyUnit` class defines common functionality for all units while specialized units implement their own specific behaviors.
- **Inheritance**: Specialized emergency units inherit from `EmergencyUnit`, reusing common logic.
- **Polymorphism**: The `RespondToIncident()` method is overridden in each derived unit to handle incidents in a unit-specific way.

## Conclusion
This simulation demonstrates how object-oriented principles can model real-world emergency response scenarios with various specialized units, each responding differently to a variety of incidents.
