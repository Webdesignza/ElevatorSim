using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicElevatorSim;
using System.Globalization;
using Spectre.Console;

namespace ElevatorSim
{
    public static class Global
    {
        // Static Connectionstring to be used in the appplication setup at startup 
        public static string strConnectionString = string.Empty;

        /// <summary>
        /// Method to be called at the startup of application to setup all global variables
        /// </summary>
        public static void SetupGlobals() 
        {
            GetConnectionString();
        }

        /// <summary>
        /// Used to setup the connection string to be used as a static value thorugh the application
        /// </summary>
        private static void GetConnectionString()
        {
            // Declarations
            strConnectionString = string.Empty;
            string? strEncrypted = null;
            
            // Get the secret key from the file system
            using (StreamReader r = new StreamReader("ElevatorSim.txt"))
            {
                string strKey = r.ReadToEnd();

                // Get the encrypted connection strin from the file system
                strEncrypted = ConfigurationManager.ConnectionStrings["ElevatorSimDb"].ToString();

                // Check if the connectionsting is not nulll
                if (strEncrypted != null)
                {
                    // Now setup the global static variable for the connection string
                    strConnectionString = BLSecurity.DecryptStringFromString(strEncrypted,
                                                                             Encoding.UTF8.GetBytes(strKey),
                                                                             Encoding.UTF8.GetBytes(strKey.Substring(0, 16)));
                }
            }
        }

        /// <summary>
        /// This method will add a heading on the Console display
        /// </summary>
        /// <param name="prmHeadingText">The heading to display</param>
        public static void SetupHeading(string prmHeadingText)
        {

            // Set a Heading for the application
            AnsiConsole.Write(
                new FigletText(prmHeadingText).Color(Color.Red));
        }
    }
}
