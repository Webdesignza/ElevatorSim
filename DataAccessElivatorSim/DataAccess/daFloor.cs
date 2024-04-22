using DataAccessElevatorSim.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.DataAccess
{
    public class daFloor
    {

        // declarations
        private string strConnectionString;

        public daFloor(string prmConnectionString)
        {
            strConnectionString = prmConnectionString;
        }

        /// <summary>
        /// Public method to return all elevators from the database
        /// </summary>
        /// <returns>List of Floors</returns>
        public List<entFloor> GetFloors()
        {
            // Return all Elevators from the database if no search term is sent through
            using (var context = new ElevatorSimContext(strConnectionString))
            {

                var floors = context.Floor
                .FromSqlInterpolated($"SELECT * FROM dbo.Floor")
                .OrderBy(b => b.FloorId)
                .ToList();

                return floors;
            }
        }

        /// <summary>
        /// Overloaded method to return a specific floor
        /// </summary>
        /// <param name="prmFloorId">The id of the specific floor we are looking for</param>
        /// <returns>List of Floors</returns>
        public List<entFloor> GetFloors(int prmFloorId)
        {
            // Return specific Elevator from the database 
            using (var context = new ElevatorSimContext(strConnectionString))
            {

                var floors = context.Floor
                .FromSqlInterpolated($"SELECT * FROM dbo.Floor")
                .Where(b => b.FloorId == prmFloorId)
                .OrderBy(b => b.FloorId)
                .ToList();

                return floors;
            }

        }
    }
}
