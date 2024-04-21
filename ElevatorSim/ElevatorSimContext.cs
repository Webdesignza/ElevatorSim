using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessElevatorSim.Models;
using System.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using BusinessLogicElevatorSim;

namespace DataAccessElevatorSim
{
    public class ElevatorSimContext : DbContext
    {
        public ElevatorSimContext()        
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string strConnectionString = string.Empty;
            string? strEncrypted = null;

            using (StreamReader r = new StreamReader("ElevatorSim.txt"))
            {
                string strKey = r.ReadToEnd();

                // Check if the connectionsting is not nulll
               
                    strEncrypted =ConfigurationManager.ConnectionStrings["ElevatorSimDb"].ToString();;

                if (strEncrypted != null)
                {
                    strConnectionString = BLSecurity.DecryptStringFromString(strEncrypted,
                                                                             Encoding.UTF8.GetBytes(strKey),
                                                                             Encoding.UTF8.GetBytes(strKey.Substring(0, 16)));
                }
            }
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
