using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entElevatorType
    {
        [Key]
        public int ElevatorTypeId { get; set; }

        public required string ElevatorTypeName { get; set; }
        public required string ElevatorTypeDescription { get; set; }
        public int MaxLoad {  get; set; }
        public required entLoadType LoadType {  get; set; }
       
    }
}
