using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entShaft
    {
        [SetsRequiredMembers]
        public entShaft()
        {
            ShaftDescription = string.Empty;
            Building = new entBuilding();
        }

        [Key]
        public int ShaftId {  get; set; }

        public required string ShaftDescription { get; set; }

        public required entBuilding Building { get; set; }
    }
}
