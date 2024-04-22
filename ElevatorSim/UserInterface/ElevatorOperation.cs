using DataAccessElevatorSim.DataAccess;
using DataAccessElevatorSim.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSim.UserInterface.UserInterface
{
    public class ElevatorOperation
    {
        // Class Declarations
        List<entElevator> lstElevators = new List<entElevator>();
        List<entFloor> lstFloors = new List<entFloor>();

        private System.Timers.Timer? tmrTimer;

        /// <summary>
        /// Starts the timer to update the display to show location of the elevator
        /// </summary>
        private void StartTimer()
        {
            // Create a timer and set a two second interval.
            tmrTimer = new System.Timers.Timer();
            tmrTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
            tmrTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            tmrTimer.AutoReset = true;

            // Start the timer
            tmrTimer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
        }

        /// <summary>
        /// Timer Ticked event will update the display to show elevator movements
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(Object? source, System.Timers.ElapsedEventArgs e)
        {
            UpdateDisplay();
        }

        /// <summary>
        /// public method to update the display that shows current statusses of all the elevators
        /// </summary>
        public void OperationDisplaySetup()
        {
            // Clear the Console and update the Heading
            Console.Clear();
            Global.SetupHeading("Elevator Operation");
            // Let user know we are lodaing
            Console.WriteLine("Loading....");

            // Declarations
            daElevator elevatorDA = new daElevator(Global.strConnectionString);
            daFloor floorDA = new daFloor(Global.strConnectionString);


            // Load the Elevators from the database
            if (Global.strConnectionString != null)
            {

                lstElevators = elevatorDA.GetElevators();
            }

            // If there are no Elevators in the database then we need to add some
            if (lstElevators.Count == 0)
            {
                AnsiConsole.Markup(string.Concat("[green]There are no Elevators setup yet, ",
                                                 "/n please setup some elevators to track  [/]",
                                                 "Press any Key to return to the main menu :"));
                Console.ReadLine();
                return;
            }

            // Load the Elevators from the database
            if (Global.strConnectionString != null)
            {

                lstFloors = floorDA.GetFloors();
            }

            // If there are no Elevators in the database then we need to add some
            if (lstFloors.Count == 0)
            {
                AnsiConsole.Markup(string.Concat("[green]There are no Floors setup yet, ",
                                                 "/n please setup some floors to track  [/]",
                                                 "Press any Key to return to the main menu :"));
                Console.ReadLine();
                return;
            }
            
            // Remove the Loading text
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine("                     ");


            // Start the Live Display of the Elevators
            // Create a table
            var table = new Table();

            // Add the Column for the Floors
            table.AddColumn("Floors");

            foreach (entElevator feElevator in lstElevators)
            {
                // Add All the Elevators as Columns
                table.AddColumn("[blue]Shaft[/]");

            }

            // Now add a row for each floor
            table.AddRow(["[green]Seventh[/]","",""]);
            table.AddRow(["[green]Sixth[/]", "", ""]);
            table.AddRow(["[green]Fith[/]", "", ""]);
            table.AddRow(["[green]Fourth[/]", "", ""]);
            table.AddRow(["[green]Third[/]", "", "[red]Elevator 2[/]"]);
            table.AddRow(["[green]Second[/]", "", ""]);
            table.AddRow(["[green]First[/]", "", ""]);
            table.AddRow(["[green]Ground[/]", "[red]Elevator 1[/]", ""]);

            // Render the table to the console
            AnsiConsole.Write(table);


            // Start the timer
            StartTimer();
        }

        /// <summary>
        /// Update the display to show the elevator movement
        /// </summary>
        private void UpdateDisplay()
        {
            
            Console.SetCursorPosition(10, Console.CursorTop - 7);
            Console.WriteLine("                     ");
        }
    }
}
