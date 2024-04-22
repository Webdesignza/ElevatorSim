using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DataAccessElevatorSim.Models
{
    public class entElevator
    {
        [SetsRequiredMembers]
        public entElevator()
        {
            // Set required fields
            ElevatorName = string.Empty;
            ElevatorType = new entElevatorType();
            Shaft = new entShaft();
            CurrentFloor = new entFloor();
        }

        [Key]
        public int ElevatorId {  get; set; }

        public required string ElevatorName { get; set; }

        public required entElevatorType ElevatorType { get; set; }

        public required entShaft Shaft { get; set; }

        public bool IsMoving { get; set; }

        public bool IsGoingUp { get; set; } 

        public required entFloor CurrentFloor { get; set; }

        public int CurrentLoadCount { get; set; }

    }
}
