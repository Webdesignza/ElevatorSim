using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entLoadType
    {
        [Key]
        public int LoadTypeId {  get; set; }

        public required string LoadDescription {  get; set; }
    }
}
