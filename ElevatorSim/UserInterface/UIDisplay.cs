using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogicElevatorSim;
using DataAccessElevatorSim.DataAccess;
using DataAccessElevatorSim.Models;
using ElevatorSim.UserInterface.UserInterface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Spectre.Console;

namespace ElevatorSim.UserInterface
{
    public class UIDisplay
    {

        // Declarations
        ElevatorOperation clsOperation = new ElevatorOperation();
        DbMaintenance clsDbMaintenance = new DbMaintenance();

        /// <summary>
        /// Constructor for the User Interface class to setup the initial display of the application
        /// </summary>
        public UIDisplay()
        {
            Global.SetupHeading("Elevator Simulator");
        }
               

        /// <summary>
        /// Setup the initial menu for displaying on the home page
        /// </summary>
        public string InitiateHomeMenu()
        {
            // Let user select the Elevator Type
            var menuItemSelected = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Welcome, Please select an option.")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to make a selection)[/]")
                    .AddChoices("1.Elevator Operation", "2.Maintenance Menu", "3.Exit Program"));

            // Send back the choice of what to do
            return menuItemSelected;
        }

        /// <summary>
        /// This public method will cha all instances and properties of the elevators and update the display
        /// </summary>
        public void Operation()
        {
            // Update the live display of the Elevators
            clsOperation.OperationDisplaySetup();

        }



        
    }

}
