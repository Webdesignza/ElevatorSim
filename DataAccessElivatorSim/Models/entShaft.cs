using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entShaft:EntityBase
    {
        public required string ShaftDescription { get; set; }

        public required List<entFloor> AllowedFloors { get; set; }
    }
}
