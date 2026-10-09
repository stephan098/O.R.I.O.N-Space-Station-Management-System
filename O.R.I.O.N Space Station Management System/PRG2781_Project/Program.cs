using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    internal class Program
    {
        static List<string> recentAlerts = new List<string>(); // list to store recent alerts

        static void Main(string[] args)
        {
            Console.WriteLine("Booting O.R.I.O.N Space Station Operations...");

            StationManager coreComputer = new StationManager();
            RandomModuleGenerator generator = new RandomModuleGenerator();
            FileManager fileManager = new FileManager();

            coreComputer.OnAlertTriggered += LogAlertToConsole;
            coreComputer.OnTaskCompleted += LogNotificationToConsole; // Subscribe methods to custom system events 

            bool running = true;

            while (running)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("O.R.I.O.N SPACE STATION");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Generate Random Module");
                Console.WriteLine("2. Display Modules");
                Console.WriteLine("3. Remove Module");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Load");
                Console.WriteLine("6. Live Simulation Run");
                Console.WriteLine("7. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        StationModule module = generator.GenerateRandomModule();
                        coreComputer.AddModule(module);
                        Console.WriteLine("Random module generated successfully!");
                    break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Initializing Live Station Dashboard...");
                        Console.WriteLine("Press ANY KEY to exit the dashboard and return to the menu.");
                        System.Threading.Thread.Sleep(2000); // 2 seconds to read the instructions

                         
                        while (!Console.KeyAvailable) // Loops and clears the console constantly until a key is pressed
                        {
                            Console.Clear();
                            coreComputer.DisplayAllModules();

                            if (recentAlerts.Count > 0) // pushing the alerts back in so it doesnt dissapear
                            {
                                Console.WriteLine("\n=== RECENT SYSTEM ALERTS ===");
                                Console.ForegroundColor = ConsoleColor.Red;
                                foreach (string alert in recentAlerts)
                                {
                                    Console.WriteLine(alert);
                                }
                                Console.ResetColor();
                            }

                            Console.WriteLine("\n[Press ANY KEY to return to menu]");
                            System.Threading.Thread.Sleep(1000); // Refresh the screen every 1 seconds
                        }

                        Console.ReadKey(true); // Consumes the key press so it doesn't mess up the menu
                    break;

                    case "3":
                        Console.Clear();
                        Console.Write("Enter Module ID: ");
                        string id = Console.ReadLine();
                        coreComputer.RemoveModule(id);
                    break;

                    case "4":
                        Console.Clear();
                        string dataToSave = coreComputer.GetSystemStateForSaving();
                        fileManager.Save(dataToSave);
                        Console.WriteLine("Data saved successfully!");
                    break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine(fileManager.Load());
                    break;

                    case "6": 
                        Console.Clear();
                        coreComputer.RunSimulationOperations();
                    break;

                    case "7":
                        running = false;
                    break;

                    default:
                        Console.WriteLine("Invalid option.");
                    break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void LogAlertToConsole(string alertMessage) // Event Listener Actions responding to delegate invocation
        {
            recentAlerts.Add($"[CRITICAL ENGINE ALERT]: {alertMessage}"); // save the alert to the history list

            if (recentAlerts.Count > 5) // keep only the 5 most recent alerts so the screen doesn't get too long
            {
                recentAlerts.RemoveAt(0);
            }

            Console.ForegroundColor = ConsoleColor.Red; // Still print it immediately in case we aren't currently in the dashboard
            Console.WriteLine($"\n[CRITICAL ENGINE ALERT]: {alertMessage}");
            Console.ResetColor();
        }

        private static void LogNotificationToConsole(string taskDetails)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Sets the color of the Console.WriteLine to Cyan
            Console.WriteLine($"[ENGINE EVENT]: {taskDetails}");
            Console.ResetColor(); // Resets the color to normal console text
        }
    }
}
