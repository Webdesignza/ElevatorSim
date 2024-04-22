using DataAccessElevatorSim;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using BusinessLogicElevatorSim;
using static System.Net.Mime.MediaTypeNames;
using ElevatorSim;
using ElevatorSim.UserInterface;

// First setup global variables
Global.SetupGlobals();

// Declarations
string strUserInput = string.Empty;
UIDisplay uiElevatorSim = new UIDisplay();

// Keep running until user exits
while (strUserInput.IndexOf("3") < 0)
{
    // Keep showing some menu until the user exits
    strUserInput = uiElevatorSim.InitiateHomeMenu();

    // Call the Operation according to what the user selects
    // -----------------------------------------------------

    // Elevator Operation
    if (strUserInput.IndexOf("1") > -1)
    {
        uiElevatorSim.Operation();
    }

    
    
}




