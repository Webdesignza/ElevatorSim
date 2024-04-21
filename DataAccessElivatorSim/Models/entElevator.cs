using System.ComponentModel.DataAnnotations;

namespace DataAccessElevatorSim.Models
{
    public class entElevator
    {
        [Key]
        public int ElevatorId {  get; set; }

        public required string ElevatorName { get; set; }

        public required string ElevatorType { get; set; }

        public required entShaft Shaft { get; set; }

        public bool blnIsMoving { get; set; }

        public bool blnIsGoingUp { get; set; } 

        public required entFloor CurrentFloor { get; set; }

        public int CurrentLoadCount { get; set; }

    }
}
