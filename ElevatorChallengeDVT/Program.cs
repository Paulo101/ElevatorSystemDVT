// See https://aka.ms/new-console-template for more information
using ElevatorLibrary.Classes;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

//Console window in the centre of the screen
SetWindow(600, 500);


//Assuming the elevator system has 3 elevators, each elevator has a capacity of 10 people and a max weight of 800
ElevatorSystem elevatorSystem = new ElevatorSystem(3, 10, 800);


//Calling the menu
Menu();
void Menu()
{

    //Header
    CLS("Elevator Stystem");

    //Options
    Console.WriteLine("\tA. Request Elevator.");
    Console.WriteLine("\tX. Exit.");

    //Get user choice
    Console.Write("\n\tOption : ");
    char option = char.ToUpper(Console.ReadKey().KeyChar);

    //Branch out
    switch (option)
    {
        case 'A': RequestElevator(); break;
        case 'X': Environment.Exit(0); break;
        default: Menu(); break;
    }
    Console.ReadKey();
}

void RequestElevator()
{
    //Get user input.
    Console.WriteLine("\n\tPlease provide the inputs below. Press 'N' once done.");

    int floorTo = GetInputAsInteger("\tPlease provide Floor Number: ");
    int persons = GetInputAsInteger("\tPlease provide the number of people: ");
    int weight = GetInputAsInteger("\tPlease provide weight: ");

    elevatorSystem.SelectFloorTo(floorTo, persons, weight);

    //Request Another Elevator
    Console.Write("\n\tRequest Another Elevator (Y/N) : ");
    char option = char.ToUpper(Console.ReadKey().KeyChar).ToString().ToLower()[0];

    //if yes, request again
    if (option == 'y')
        RequestElevator();
    else
    {
        Console.WriteLine("\n\tPress any key to return to menu");
        Console.ReadKey();
        Menu();
    }

    //else exit the method

}

//Repeats the prompt until user provides correct input
int GetInputAsInteger(string sPrompt)
{
    Console.Write(sPrompt);
    int results = 0;
    if (!int.TryParse(Console.ReadLine(), out results))
        return GetInputAsInteger(sPrompt);
    return results;
}

#region ConsoleScreenSettings
static void SetWindow(int w, int h)
{
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Clear();

    IntPtr ptr = GetConsoleWindow();
    MoveWindow(ptr, (1920 - w) / 2, (1080 - h) / 2, w, h, true);
} //SetWindow


[DllImport("user32.dll", SetLastError = true)]
static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

[DllImport("kernel32.dll", SetLastError = true)]
static extern IntPtr GetConsoleWindow();

static void CLS(string header)
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine("\t" + header);
    Console.WriteLine("\t" + "".PadRight(header.Length, '='));
    Console.WriteLine();
} //CLS

#endregion
