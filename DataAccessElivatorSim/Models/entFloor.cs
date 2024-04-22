using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entFloor
    {
        [SetsRequiredMembers]
        public entFloor() 
        {
            FloorDescription = string.Empty;
            Building = new entBuilding();
        }

        [Key]
        public int FloorId { get; set; }

        public required string FloorDescription { get; set; }

        public required entBuilding Building { get; set; }
    }
}
