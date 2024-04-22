using BusinessLogicElevatorSim;
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
    public class DbMaintenance
    {

        /// <summary>
        /// This method will setup the UI to add a new elevator to the database
        /// </summary>
        private void AddElevator()
        {
            // Declarations
            // -------------
            entElevator newElevator = new entElevator();
            BLElevator blElevator = new BLElevator(Global.strConnectionString);

            // First clear the console page
            Console.Clear();

            // Update the Heading
            Global.SetupHeading("Add new Elevator");

            // User selects the Elevevator Type
            // ---------------------------------

            // Get all elevator Types
            daElevatorType elevType = new daElevatorType(Global.strConnectionString);

            List<entElevatorType> lstElevatorTypes = elevType.GetElevatorTypes();

            // Convert to string Array           
            string[] arChoices = new string[lstElevatorTypes.Count];

            for (int intCounter = 0; intCounter < lstElevatorTypes.Count; intCounter++)
            {
                arChoices[intCounter] = lstElevatorTypes[intCounter].ElevatorTypeName;
            }

            // Let user select the Elevator Type
            var elevatorTypesSelected = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select what type of elevator you want to add.")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more Elevator Types)[/]")
                    .AddChoices(arChoices));

            // Get the one selected
            foreach (entElevatorType feType in lstElevatorTypes)
            {
                if (feType.ElevatorTypeName == elevatorTypesSelected.ToString())
                {
                    newElevator.ElevatorType = feType;
                    break;
                }
            }


            // Now user selects the Shaft the elevator runs in
            // ------------------------------------------------
                   

            // Get all elevator Types
            daShaft shaft = new daShaft(Global.strConnectionString);

            List<entShaft> lstShafts = shaft.GetShafts();

            // Convert to string Array           
            arChoices = new string[lstShafts.Count];

            for (int intCounter = 0; intCounter < lstShafts.Count; intCounter++)
            {
                arChoices[intCounter] = lstShafts[intCounter].ShaftDescription;
            }

            // Let user select the Elevator Type
            var shaftSelected = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select which shaft the new elevator will run in.")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more Shafts)[/]")
                    .AddChoices(arChoices));

            // Get the one selected
            foreach (entShaft feShaft in lstShafts)
            {
                if (feShaft.ShaftDescription == shaftSelected.ToString())
                {
                    newElevator.Shaft = feShaft;
                    break;
                }
            }

            // Ask user to enter a name for the new elevator
            AnsiConsole.Markup("Please enter [green]a name[/] to use for the new elevator:");
            newElevator.ElevatorName = Console.ReadLine() ?? string.Empty;

            // Reset console display again
            Console.Clear();
            Global.SetupHeading("Add new Elevator");

            // Now we can go ahead and add the new elevator
            AnsiConsole.Markup(string.Concat("[red]", blElevator.AddElevator(newElevator), "[/]"));


        }
    }
}
