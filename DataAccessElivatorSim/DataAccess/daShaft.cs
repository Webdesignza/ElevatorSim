using DataAccessElevatorSim.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.DataAccess
{
    public class daShaft
    {
        // declarations
        private string strConnectionString;


        public daShaft(string prmConnectionString)
        {
            strConnectionString = prmConnectionString;
        }

        /// <summary>
        /// Public method to return all elevator types from the database
        /// </summary>
        /// <returns>List of Shafts from the database</returns>
        public List<entShaft> GetShafts()
        {
            // Return all Elevators from the database if no search term is sent through
            using (var context = new ElevatorSimContext(strConnectionString))
            {

                var shafts = context.Shaft
                .FromSqlInterpolated($"SELECT * FROM dbo.Shaft")
                .OrderBy(b => b.ShaftId)
                .ToList();

                return shafts;
            }
        }
    }
}
