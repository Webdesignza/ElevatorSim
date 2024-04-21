using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entFloor
    {
        [Key]
        public int FloorId { get; set; }

        public required string FloorDescription { get; set; }
    }
}
