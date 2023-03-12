namespace ElevatorChallenge
{
    /// <summary>
    /// Contains methods for simulating elevator movement.
    /// </summary>
    public class ElevatorSimulation
    {
        /// <summary>
        /// Simulates the movement of an elevator to its destination floor.
        /// </summary>
        /// <param name="elevator">The elevator to simulate.</param>
        /// <param name="displayElevatorsStatus">An action to display the current status of all elevators.</param>
        public static void SimulateElevatorMovement(Elevator elevator, Action displayElevatorsStatus)
        {
            Console.WriteLine($"Elevator {elevator.Id} is in motion.");

            elevator.IsMoving = true;

            // Simulate elevator moving to the distination floor
            while (elevator.CurrentFloor != elevator.DestinationFloor)
            {
                if (elevator.CurrentFloor < elevator.DestinationFloor)
                {
                    elevator.IsGoingUp = true;
                    elevator.CurrentFloor++;
                }
                else
                {
                    elevator.IsGoingUp = false;
                    elevator.CurrentFloor--;
                }

                displayElevatorsStatus();
                Console.WriteLine("\nSimulation elevator movement at 1 sec/floor, please wait . . .");
                Thread.Sleep(1000); // Pause for 1 second to simulate elevator movement
            }

            elevator.IsMoving = false;
            displayElevatorsStatus();

            var peopleMessage = elevator.NumberOfPeopleInside > 0 ? $"with {elevator.NumberOfPeopleInside} person/people" : string.Empty;

            Console.WriteLine($"\nElevator {elevator.Id} has arrived at your floor {elevator.DestinationFloor} {peopleMessage}.\n");

            // Reset the number of people in the elevator
            elevator.NumberOfPeopleInside = 0;
        }
    }
}
