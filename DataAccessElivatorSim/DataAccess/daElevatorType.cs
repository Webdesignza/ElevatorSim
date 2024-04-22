using DataAccessElevatorSim.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.DataAccess
{
    public class daElevatorType
    {
        // declarations
        private string strConnectionString;


        public daElevatorType(string prmConnectionString)
        {
            strConnectionString = prmConnectionString;
        }

        /// <summary>
        /// Public method to return all elevator types from the database
        /// </summary>
        /// <returns></returns>
        public List<entElevatorType> GetElevatorTypes()
        {
            // Return all Elevators from the database if no search term is sent through
            using (var context = new ElevatorSimContext(strConnectionString))
            {

                var elevatorTypes = context.ElevatorType
                .FromSqlInterpolated($"SELECT * FROM dbo.Elevatortype")
                .OrderBy(b => b.ElevatorTypeId)
                .ToList();

                return elevatorTypes;
            }
        }
    }
}
