using System;

// Main prorgam class
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your personal journal!");
        Console.WriteLine("Don't forget to write something every day :)");

        Journal journal = new Journal();
        bool running = true;

        // Main program loop - 
        while (running)
        {
            // Menu
            Console.WriteLine("\n1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. View mood statistics");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            // Handle their choice 
            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    journal.DisplayMoodStatistics();
                    break;
                case "6":
                    Console.WriteLine("\nThanks for journaling today! See you tomorrow!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}