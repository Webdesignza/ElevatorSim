using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entErrors
    {
        [Key]
        public int ErrorId { get; set; }

        public required string ErrorNumber {  get; set; }

        public required string ErrorDescription { get; set; }
    }
}
