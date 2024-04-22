using DataAccessElevatorSim.DataAccess;
using DataAccessElevatorSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicElevatorSim
{
    public class BLElevator
    {
        // Declarations
        string strConnectionstring = string.Empty;

        public BLElevator(string prmConnectionstring) 
        {
            // Set the connection string to use in the module
            strConnectionstring = prmConnectionstring;
        }

        /// <summary>
        /// Build up all elements to add the new Elevator Object
        /// </summary>
        /// <returns>Success or Error message for adding</returns>
        public string AddElevator(entElevator prmElevator)
        {
            // Delcarations
            daElevator elevator = new daElevator(strConnectionstring);

            // Perform all validations before we add the Elevator


            // Call the dataAccess method to add the Elevator
            if (elevator.insertElevator(prmElevator))
            {
                // Success let the user know
                return "The new elevator was added";
            }
            else 
            {
                // Let the user know that something went wrong
                return "The new elevator could NOT be added.";
            }

        }

        
    }
}
