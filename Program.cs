using System;
using System.Collections.Generic;

// Abstract base class
abstract class EmergencyUnit
{
    public string Name { get; set; }
    public int Speed { get; set; }

    public EmergencyUnit(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public abstract bool CanHandle(string incidentType);
    public abstract void RespondToIncident(Incident incident);
}

// Incident class
class Incident
{
    public string Type { get; set; }
    public string Location { get; set; }
    public int Difficulty { get; set; }

    public Incident(string type, string location, int difficulty)
    {
        Type = type;
        Location = location;
        Difficulty = difficulty;
    }
}

// Specialized Units
class Police : EmergencyUnit
{
    public Police(string name, int speed) : base(name, speed) { }
    public override bool CanHandle(string incidentType) => incidentType == "Crime";
    public override void RespondToIncident(Incident incident) =>
        Console.WriteLine($"{Name} is handling crime at {incident.Location}.");
}

class Firefighter : EmergencyUnit
{
    public Firefighter(string name, int speed) : base(name, speed) { }
    public override bool CanHandle(string incidentType) => incidentType == "Fire";
    public override void RespondToIncident(Incident incident) =>
        Console.WriteLine($"{Name} is extinguishing fire at {incident.Location}.");
}

class Ambulance : EmergencyUnit
{
    public Ambulance(string name, int speed) : base(name, speed) { }
    public override bool CanHandle(string incidentType) => incidentType == "Medical";
    public override void RespondToIncident(Incident incident) =>
        Console.WriteLine($"{Name} is treating patients at {incident.Location}.");
}

class SWAT : EmergencyUnit
{
    public SWAT(string name, int speed) : base(name, speed) { }
    public override bool CanHandle(string incidentType) => incidentType == "Hostage";
    public override void RespondToIncident(Incident incident) =>
        Console.WriteLine($"{Name} is neutralizing a hostage situation at {incident.Location}.");
}

class SearchAndRescue : EmergencyUnit
{
    public SearchAndRescue(string name, int speed) : base(name, speed) { }
    public override bool CanHandle(string incidentType) => incidentType == "Earthquake";
    public override void RespondToIncident(Incident incident) =>
        Console.WriteLine($"{Name} is rescuing victims from rubble at {incident.Location}.");
}

class Hazmat : EmergencyUnit
{
    public Hazmat(string name, int speed) : base(name, speed) { }
    public override bool CanHandle(string incidentType) => incidentType == "Gas Leak";
    public override void RespondToIncident(Incident incident) =>
        Console.WriteLine($"{Name} is containing a gas leak at {incident.Location}.");
}

// Main simulation
class Program
{
    static void Main()
    {
        List<EmergencyUnit> units = new List<EmergencyUnit>
        {
            new Police("Police Unit 1", 80),
            new Firefighter("Firefighter Unit 1", 70),
            new Ambulance("Ambulance Unit 1", 90),
            new SWAT("SWAT Team", 60),
            new SearchAndRescue("SAR Team", 65),
            new Hazmat("Hazmat Unit", 55)
        };

        string[] incidentTypes = { "Crime", "Fire", "Medical", "Hostage", "Earthquake", "Gas Leak" };
        string[] locations = { "City Hall", "Downtown", "University", "Mall", "Harbor", "Residential Area" };

        Random rand = new Random();
        int score = 0;

        // Ask the user whether they want manual or automatic selection
        Console.WriteLine("Do you want to select a unit manually or automatically?");
        Console.WriteLine("1. Manual Selection");
        Console.WriteLine("2. Automatic Selection");

        int selectionChoice;
        while (!int.TryParse(Console.ReadLine(), out selectionChoice) || (selectionChoice != 1 && selectionChoice != 2))
        {
            Console.Write("Invalid input. Try again: ");
        }

        bool isManualSelection = selectionChoice == 1;

        for (int turn = 1; turn <= 5; turn++)
        {
            Console.WriteLine($"\n--- Turn {turn} ---");

            string type = incidentTypes[rand.Next(incidentTypes.Length)];
            string location = locations[rand.Next(locations.Length)];
            int difficulty = rand.Next(1, 11);

            Incident incident = new Incident(type, location, difficulty);
            Console.WriteLine($"Incident: {incident.Type} at {incident.Location} (Difficulty: {difficulty})");

            Console.WriteLine("\nAvailable Units:");
            for (int i = 0; i < units.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {units[i].Name} (Speed: {units[i].Speed})");
            }

            EmergencyUnit selectedUnit;

            if (isManualSelection)
            {
                Console.Write("Select a unit by number: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > units.Count)
                {
                    Console.Write("Invalid input. Try again: ");
                }
                selectedUnit = units[choice - 1];
            }
            else
            {
                // Automatic selection: Randomly select a unit
                selectedUnit = units[rand.Next(units.Count)];
                Console.WriteLine($"Automatic selection: {selectedUnit.Name}");
            }

            if (selectedUnit.CanHandle(incident.Type))
            {
                selectedUnit.RespondToIncident(incident);
                int responseTime = 100 - selectedUnit.Speed;
                int pointsEarned = 10 + incident.Difficulty - (responseTime / 10);
                score += pointsEarned;
                Console.WriteLine($"+{pointsEarned} points (Response time: {responseTime})");
            }
            else
            {
                Console.WriteLine($"{selectedUnit.Name} cannot handle {incident.Type}.");
                score -= 5;
                Console.WriteLine("-5 points");
            }

            Console.WriteLine($"Current Score: {score}");
        }

        Console.WriteLine($"\nFinal Score: {score}");
    }
}
