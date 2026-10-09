using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    internal delegate void StationAlertHandler(string alertMessage); // Custom delegates to notify subscribers when system events occur
    internal delegate void SystemTaskHandler(string taskDetails);

    internal class StationManager
    {
        private readonly object lockObject = new object(); // Thread lock object to ensure safe multithreaded collection modifications

        public event StationAlertHandler OnAlertTriggered; // Two custom events
        public event SystemTaskHandler OnTaskCompleted;

        public StationManager()
        {
            // Start the independent background monitoring process
            Thread monitoringThread = new Thread(BackgroundSystemMonitor);
            monitoringThread.IsBackground = true; // Ensures the thread ends when the application closes
            monitoringThread.Start();
        }

        private void BackgroundSystemMonitor()
        {
            Random rand = new Random();
            while (true)
            {
                Thread.Sleep(7000); // Runs quietly every 7 seconds completely independent of user input

                lock (lockObject) // Prevent cross-thread collection crashing
                {
                    if (activeModules.Count > 0)
                    {
                        // Randomly degrade an active module's integrity to simulate space fatigue
                        int targetIndex = rand.Next(activeModules.Count);
                        var target = activeModules[targetIndex];

                        if (target is iMaintainable maintainable)
                        {

                            int oldIntegrity = maintainable.IntegrityLevel;
                            int newIntegrity = Math.Max(0, oldIntegrity - rand.Next(5, 15)); // Caps the integrity to 0 so it doesnt go to the negative
                            maintainable.IntegrityLevel = newIntegrity;

                            // Trigger Alert Event if integrity drops dangerously low (50%)
                            if (oldIntegrity >= 50 && newIntegrity < 50)
                            {
                                OnAlertTriggered?.Invoke($"CRITICAL ALERT: Module [{target.ModuleID}] structural integrity drops below 50%!");
                            }
                        }
                    }
                }
            }
        }

        private List<StationModule> activeModules = new List<StationModule>(); // Entity Management (creation, modifcation, removal)

        public void AddModule(StationModule newModule) // Creation of the modules
        {
            activeModules.Add(newModule);
            Console.WriteLine($"SUCCESS: Module [{newModule.ModuleID}] added to the grid");
        }

        public void DisplayAllModules() // Reading of the modules (displaying all the modules)
        {
            Console.WriteLine($"\n === O.R.I.O.N. STATION STATUS ===");

            foreach (StationModule item in activeModules)
            {
                item.RunDiagnostics();
            }
        }

        public void RemoveModule(string idToRemove) // Removal of module (with error handling)
        {
            Console.WriteLine($"\nInitiating removal sequence for Module [{idToRemove}] ...");

            try // Try-Catch blocks
            {
                StationModule moduleToRemove = activeModules.Find(m => m.ModuleID == idToRemove);

                if (moduleToRemove == null)
                {
                    Console.WriteLine($"Error: Module not found in active directory");
                    return;
                }

                if (moduleToRemove is LifeSupportModule) // Domain-Specific Rule: Cannot delete life support...
                {
                    throw new CriticalSystemFailureException("ILLEGAL OPERATION: Cannot remove life support while active crew abort!"); // Throwing the custom exception for a logical error
                }

                activeModules.Remove(moduleToRemove);
                Console.WriteLine($"SUCCESS: Module [{idToRemove}] has been successfully removed.");
            }

            catch (CriticalSystemFailureException ex)
            {
                Console.WriteLine($"[SECURITY OVERRIDE FAILED] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SYSTEM CRASH] {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"--> Entity removal protocal logged in system archives.");
            }

        }

        public string GetSystemStateForSaving() // Saving the data to the file
        {
            string saveData = "O.R.I.O.N Space Station Data \n"; // Title of the data

            foreach (StationModule module in activeModules) // foreach module in the activeModules list will be saved 
            {
                saveData += module.ToString() + "\n";
            }

            return saveData; // returns the saved data
        }

        public void RunSimulationOperations()
        {
            Console.WriteLine("\n--- STARTING CONCURRENT STATION SIMULATION OPRERATIONS ---");

            // Safe Execution using multiple separate threads executing tasks at the same time
            Thread t1 = new Thread(() => ExecuteSimulationTask("Adjusting Solar Array alignment parameters", 3000));
            Thread t2 = new Thread(() => ExecuteSimulationTask("Running full automated bio-shield calibration", 2000));
            Thread t3 = new Thread(() => ExecuteSimulationTask("Processing dark matter deep space data stream", 4500));

            t1.Start();
            t2.Start();
            t3.Start();

            // Wait for threads to safely finish work before handing menu control back to the terminal
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("--- SIMULATION SEQUENCE EXECUTED ---");
        }

        private void ExecuteSimulationTask(string description, int duration)
        {
            Console.WriteLine($"[ENGAGED] Concurrent Process: {description}...");
            Thread.Sleep(duration); // Simulates work over several seconds
            Console.WriteLine($"[RESOLVED] Process Finished: {description}.");
            OnTaskCompleted?.Invoke($"Background process thread successfully completed operation: {description}");
        }
    }
}
