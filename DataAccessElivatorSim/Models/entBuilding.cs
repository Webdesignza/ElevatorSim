using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entBuilding
    {
        [Key]
        public int BuildingId { get; set; }

        public required string BuildingName { get; set; }

        public required List<entShaft> Shafts { get; set; }

        public required List<entFloor> Floors { get; set; }
    }
}
