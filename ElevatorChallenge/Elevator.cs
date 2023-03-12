namespace ElevatorChallenge
{
    /// <summary>
    /// Represents an elevator that can move between floors and transport people.
    /// </summary>
    public class Elevator
    {
        /// <summary>
        /// Gets the unique identifier of the elevator.
        /// </summary>
        public int Id { get;  }

        /// <summary>
        /// Gets or sets the current floor of the elevator.
        /// </summary>
        public int CurrentFloor { get; set; }

        /// <summary>
        /// Gets or sets the destination floor of the elevator.
        /// </summary>
        public int DestinationFloor { get; set; }

        /// <summary>
        /// Gets the maximum floor that the elevator can travel to.
        /// </summary>
        public int MaxFloor { get; }

        /// <summary>
        /// Gets the maximum number of people that the elevator can transport.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Gets or sets the number of people currently inside the elevator.
        /// </summary>
        public int NumberOfPeopleInside { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the elevator is moving.
        /// </summary>
        public bool IsMoving { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the elevator is going up.
        /// </summary>
        public bool IsGoingUp { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elevator"/> class with the specified identifier, maximum floor, and capacity.
        /// </summary>
        /// <param name="id">The unique identifier of the elevator.</param>
        /// <param name="maxFloor">The maximum floor that the elevator can travel to.</param>
        /// <param name="capacity">The maximum number of people that the elevator can transport.</param>
        public Elevator(int id, int maxFloor, int capacity)
        {
            var rd = new Random();
            Id = id;
            MaxFloor = maxFloor;
            Capacity = capacity;
            CurrentFloor = rd.Next(1, maxFloor + 1);
            DestinationFloor = CurrentFloor;
            IsGoingUp = true;
        }
    }
}
