using DataAccessElevatorSim.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.DataAccess
{
    public class daElevator
    {
        // declarations
        private string strConnectionString;

        public daElevator(string prmConnectionString) 
        {
            strConnectionString = prmConnectionString;
        }

        /// <summary>
        /// Public method to return all elevators from the database
        /// </summary>
        /// <returns></returns>
        public List<entElevator> GetElevators()
        {
            // Return all Elevators from the database if no search term is sent through
            using (var context = new ElevatorSimContext(strConnectionString))
            {

                var elevators = context.Elevator
                .FromSqlInterpolated($"SELECT * FROM dbo.Elevator")                
                .OrderBy(b => b.ElevatorId)
                .ToList();

                return elevators;
            }

            
        }

        /// <summary>
        /// Public method to insert a new elevator into the database
        /// </summary>
        /// <param name="prmElevator">Elevator enitity containing all properties of the new elevator</param>
        /// <returns>True if susccessfull and false if not</returns>
        public bool insertElevator(entElevator prmElevator)
        {
            // Add the new elevator to the context object and save to the database
            using (var context = new ElevatorSimContext(strConnectionString))
            { 
                context.Elevator.Add(prmElevator);
                context.SaveChanges();
            }

            return true;
        }

    }
}
