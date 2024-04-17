using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessElevatorSim.Models;

namespace DataAccessElevatorSim
{
    public class ElevatorSimContext : DbContext
    {
        // Declarations
        private string connectionString = string.Empty;

        public ElevatorSimContext(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<entBuilding> Building{ get; set; }

        public DbSet<entElevator> Elevator{ get; set; }

        public DbSet<entElevatorType> ElevatorType { get; set; }

        public DbSet<entFloor> Floor{ get; set; }

        public DbSet<entLoadType> LoadType{ get; set; }

        public DbSet<entShaft> Shaft{ get; set; }

    }
}
