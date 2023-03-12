namespace ElevatorChallenge
{
    /// <summary>
    /// The ElevatorSystem class manages the elevators in the building.
    /// </summary>
    public class ElevatorSystem
    {
        private readonly Elevator[] elevators;

        /// <summary>
        /// Gets the top floor of the building.
        /// </summary>
        public int TopFloor { get; private set; }

        /// <summary>
        /// Gets the maximum capacity of each elevator in the building.
        /// </summary>
        public int ElevatorSizeLimit { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ElevatorSystem class with the specified number of elevators, maximum floor, and maximum capacity.
        /// </summary>
        /// <param name="numElevators">The number of elevators in the building.</param>
        /// <param name="maxFloor">The maximum floor of the building.</param>
        /// <param name="maxCapacity">The maximum capacity of each elevator in the building.</param>
        public ElevatorSystem(int numElevators, int maxFloor, int maxCapacity)
        {
            elevators = new Elevator[numElevators];
            TopFloor = maxFloor;
            ElevatorSizeLimit = maxCapacity;

            for (int i = 0; i < numElevators; i++)
            {
                elevators[i] = new Elevator(i + 1, maxFloor, maxCapacity);
            }
        }

        /// <summary>
        /// Displays the status of all elevators in the building.
        /// </summary>
        public void DisplayElevatorStatus()
        {
            Console.Clear();
            Console.WriteLine("Elevator Status:");

            foreach (var elevator in elevators)
            {
                string direction = elevator.IsGoingUp ? "Up" : "Down";
                string movingStatus = elevator.IsMoving ? "Moving" : "Stopped";

                Console.ForegroundColor = elevator.IsMoving ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine($"{elevator.Id}. Current Floor: {elevator.CurrentFloor}, Destination Floor: {elevator.DestinationFloor}, People inside: {elevator.NumberOfPeopleInside}, Capacity: {elevator.Capacity}, Direction: {direction}, Moving Status: {movingStatus}");
            }
        }

        /// <summary>
        /// Gets the nearest available elevator to the specified floor and direction with the required capacity.
        /// </summary>
        /// <param name="currentFloor">The current floor where the elevator is called from.</param>
        /// <param name="numPeopleWaiting">The number of people waiting for the elevator.</param>
        /// <returns>The nearest available elevator or null if no available elevators.</returns>
        public Elevator GetNearestElevator(int currentFloor, int numPeopleWaiting)
        {
            var availableElevators = FilterElevators(currentFloor, numPeopleWaiting, elevators);

            if (availableElevators.Count == 0)
            {
                Console.WriteLine("No available elevators. Please try again later.");
                return null;
            }

            // Find the elevator with the minimum distance
            var nearestElevator = availableElevators.OrderBy(e => Math.Abs(e.CurrentFloor - currentFloor)).First();

            // Set elevator destination floor
            nearestElevator.DestinationFloor = currentFloor;

            return nearestElevator;
        }

        /// <summary>
        /// Filters the list of elevators based on the current floor and number of people waiting.
        /// </summary>
        /// <param name="currentFloor">The current floor of the requester.</param>
        /// <param name="numPeopleWaiting">The number of people waiting for an elevator.</param>
        /// <param name="elevators">The list of elevators to filter.</param>
        /// <returns>A list of elevators that can service the request.</returns>
        private List<Elevator> FilterElevators(int currentFloor, int numPeopleWaiting, Elevator[] elevators)
        {
            // Add targeted floor to filter
            var availableElevators = elevators
                .Where(
                    e =>
                    e.Capacity >= numPeopleWaiting &&
                    e.NumberOfPeopleInside + numPeopleWaiting <= e.Capacity &&
                    ((e.CurrentFloor <= currentFloor && e.IsGoingUp) ||
                    (e.CurrentFloor >= currentFloor && !e.IsGoingUp) ||
                    !e.IsMoving))
                .ToList();

            return availableElevators;
        }
    }
}
