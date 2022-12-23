// First connect to the database,
// If it doesn't exist, the file will be created
// Must create the necessary tables
// Intoduce the application, Habit Logger
// Show the menu to the user
// Execute the necessary logice based on the option chosen in the menu
// Continue the application until the user is finished


// Create the SQLiteConnection object

// Open the database file

// Introduce the application
DisplayIntroduction();

RunHabitLogger();


DisplayExit();


void RunHabitLogger()
{
    bool isDone = false;
    while (!isDone)
    {
        DisplayMenu();
        int option = ParseOption();
        ExecuteOption(option);
    }
}

void DisplayExit()
{
    Console.WriteLine("Thank you for using Habit Logger.");
    Console.WriteLine("Application is closing. Press any key...");
    Console.ReadKey();
}

void ExecuteOption(int option)
{
    switch (option)
    {
        case 0:
            break;
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
    }
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
    }
    return option;

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