using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entBuilding:EntityBase
    {
        public required string BuildingName { get; set; }

        public required List<entShaft> Shafts { get; set; }

        public required List<entFloor> Floors { get; set; }
    }
}
