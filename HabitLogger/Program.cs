using HabitLogger;
using HabitLoggerLibrary;

DisplayIntroduction();

RunHabitLogger();

DisplayExit();


void RunHabitLogger()
{
    using var connection = new HabitLoggerConnection();
    bool isDone = false;
    while (!isDone)
    {
        DisplayMenu();
        int option = ParseOption();
        isDone = ExecuteOption(option, connection);
    }
}

bool ExecuteOption(int option, HabitLoggerConnection connection)
{
    if (connection == null)
    {
        return false;
    }
    switch (option)
    {
        case (int) Options.ExitApplication:
            return false;
        case (int) Options.ReadLogs:
            ReadLogs(connection);
            break;
        case (int) Options.AddNewLog:
            AddNewLog(connection);
            break;
        case (int) Options.DeleteLog:
            DeleteLog(connection);
            break; 
        case (int) Options.UpdateLog:
            UpdateLog(connection);
            break;
        default:
            Console.WriteLine("Invalid option.");
            Console.WriteLine("Must choose one of the options given.");
            break;
    }
    return true;
}

void UpdateLog(HabitLoggerConnection connection)
{
    Console.WriteLine("Updating log...");
    int id = GetId();
    int cupsOfWater = GetCupsOfWater();
    connection.UpdateLog(id, cupsOfWater);
}

void DeleteLog(HabitLoggerConnection connection)
{
    Console.WriteLine("Delete log...");
    int id = GetId();
    connection.DeleteLog(id);

}

int GetId()
{
    Console.WriteLine("Type id of the log: ");
    string? input = Console.ReadLine();
    int id;

    while (string.IsNullOrEmpty(input) || !int.TryParse(input, out id))
    {
        Console.WriteLine("Invalid input. Type a valid id: ");
        input = Console.ReadLine();
    }
    return id;
}

void AddNewLog(HabitLoggerConnection connection)
{
    Console.WriteLine("Adding new log...");
    int cupsOfWater = GetCupsOfWater();
    connection.CreateLog(cupsOfWater);
}

int GetCupsOfWater()
{
    Console.WriteLine("Type the number of cups: ");

    string? input = Console.ReadLine();
    int cupsOfWater;


    while (string.IsNullOrEmpty(input) || !int.TryParse(input, out cupsOfWater))
    {
        Console.WriteLine("Invalid input. Type a valid number of cups: ");
        input = Console.ReadLine();
    }
    return cupsOfWater;
}

void ReadLogs(HabitLoggerConnection connection)
{
    Console.WriteLine("Read all logs...");
    var logs = connection.GetAllLogs();
    Console.WriteLine("The following are the logs: ");
    Console.WriteLine(logs);
}


int ParseOption()
{
    string? input = Console.ReadLine();
    int option;

    while (string.IsNullOrEmpty(input) || !int.TryParse(input, out option))
    {
        Console.WriteLine("Invalid input. Must be one of the options given.");
        Console.WriteLine("Displaying menu again.");
        Console.WriteLine();
        DisplayMenu();
        input = Console.ReadLine();
    }
    return option;

}

void DisplayExit()
{
    Console.WriteLine("Thank you for using Habit Logger.");
    Console.WriteLine("Application is closing. Press any key...");
    Console.ReadKey();
}

void DisplayMenu()
{
    Console.WriteLine("Choose one of the options below:");
    Console.WriteLine("Type 0: Exit Application");
    Console.WriteLine("Type 1: Show all habits");
    Console.WriteLine("Type 2: Create a new habit");
    Console.WriteLine("Type 3: Delete a habit");
    Console.WriteLine("Type 4: Update progress on a habit");
    Console.WriteLine();

}

void DisplayIntroduction()
{
    Console.WriteLine("Welcome to Habit Logger.");
    Console.WriteLine("----------------------");
    Console.WriteLine();
}