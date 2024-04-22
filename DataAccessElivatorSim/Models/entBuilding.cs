using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entBuilding
    {
        [SetsRequiredMembers]
        public entBuilding()
        {
            BuildingName = string.Empty;
        }

        [Key]
        public int BuildingId { get; set; }

        public required string BuildingName { get; set; }

    }
}
