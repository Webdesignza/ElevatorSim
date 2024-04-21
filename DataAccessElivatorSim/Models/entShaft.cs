using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entShaft
    {
        [Key]
        public int ShaftId {  get; set; }

        public required string ShaftDescription { get; set; }

        public required List<entFloor> AllowedFloors { get; set; }
    }
}
