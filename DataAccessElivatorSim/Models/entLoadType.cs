using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessElevatorSim.Models
{
    public class entLoadType
    {
        [SetsRequiredMembers]
        public entLoadType()
        {
            LoadDescription = string.Empty;
        }

        [Key]
        public int LoadTypeId {  get; set; }

        public required string LoadDescription {  get; set; }
    }
}
