using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessElevatorSim.Models;
using System.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace DataAccessElevatorSim
{
    public class ElevatorSimContext : DbContext
    {
        // Declarations
        private string strConnectionString;

        /// <summary>
        /// Constructor recieving the connection string
        /// </summary>
        /// <param name="prmConnectionstring"></param>
        public ElevatorSimContext(string prmConnectionstring)        
        {
            strConnectionString = prmConnectionstring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                        
            // Connect to the Azure SQL Server
            optionsBuilder.UseSqlServer(strConnectionString, builder => builder.EnableRetryOnFailure());
        }

        public DbSet<entBuilding> Building{ get; set; }

        public DbSet<entElevator> Elevator{ get; set; }

        public DbSet<entElevatorType> ElevatorType { get; set; }

        public DbSet<entFloor> Floor{ get; set; }

        public DbSet<entLoadType> LoadType{ get; set; }

        public DbSet<entShaft> Shaft{ get; set; }

        public DbSet<entErrors> Errors { get; set; }

    }
}
