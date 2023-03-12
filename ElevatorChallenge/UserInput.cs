namespace ElevatorChallenge
{
    /// <summary>
    /// Class containing static methods for getting user input
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Initializes a new instance of the ElevatorSystem class with user-specified settings.
        /// </summary>
        /// <returns>A new instance of the ElevatorSystem class.</returns>
        public static ElevatorSystem InitializeElevatorSystem()
        {
            // Get user input for the number of elevators
            int numElevators = GetPositiveIntegerInput("Enter the number of elevators: ");

            // Get user input for the maximum floor
            int maxFloor = GetPositiveIntegerInput("Enter the maximum floor: ");

            // Get user input for the maximum capacity
            int maxCapacity = GetPositiveIntegerInput("Enter the maximum capacity: ");

            // Create and return a new ElevatorSystem instance
            return new ElevatorSystem(numElevators, maxFloor, maxCapacity);
        }

        /// <summary>
        /// Prompts the user to enter a floor number between 1 and the specified maximum floor, and returns the user's input as an integer.
        /// </summary>
        /// <param name="maxFloor">The maximum allowed floor number.</param>
        /// <returns>The user's input floor number as an integer.</returns>
        public static int GetFloorNumber(int maxFloor)
        {
            int floor;

            do
            {
                Console.WriteLine($"Please enter your floor number (1 - {maxFloor}):");
                string floorInput = Console.ReadLine();

                bool isFloorValid = int.TryParse(floorInput, out floor) && floor >= 1 && floor <= maxFloor;

                if (!isFloorValid)
                {
                    Console.WriteLine($"Invalid floor number. Please enter a number between 1 and {maxFloor}.");
                }
            } while (floor < 1 || floor > maxFloor);

            return floor;
        }

        /// <summary>
        /// Prompts the user to enter a direction (up or down) and returns the user's input as a boolean.
        /// </summary>
        /// <returns>True if the user enters 1 (up), false if the user enters 0 (down).</returns>
        public static bool GetDirection()
        {
            int direction;

            do
            {
                Console.WriteLine("Please enter your direction (1 for up, 0 for down):");
                var directionInput = Console.ReadLine();

                var isDirectionValid = int.TryParse(directionInput, out direction) && (direction == 0 || direction == 1);

                if (!isDirectionValid)
                {
                    Console.WriteLine("Invalid direction. Please enter 1 for up or 0 for down.");
                }
            } while (direction != 0 && direction != 1);

            return direction == 1;
        }

        /// <summary>
        /// Prompts the user to enter the number of people waiting (up to the specified maximum capacity) and returns the user's input as an integer.
        /// </summary>
        /// <param name="maxCapacity">The maximum capacity of the elevator.</param>
        /// <returns>The user's input number of people waiting as an integer.</returns>
        public static int GetNumPeopleWaiting(int maxCapacity)
        {
            int numPeople;

            do
            {
                Console.WriteLine($"Please enter the number of people waiting (up to {maxCapacity}):");
                string numPeopleInput = Console.ReadLine();

                bool isNumPeopleValid = int.TryParse(numPeopleInput, out numPeople) && numPeople >= 0 && numPeople <= maxCapacity;

                if (!isNumPeopleValid)
                {
                    Console.WriteLine($"Invalid number of people. Please enter a number between 0 and {maxCapacity}.");
                }
            } while (numPeople < 0 || numPeople > maxCapacity);

            return numPeople;
        }

        /// <summary>
        /// Prompts the user to select the floor they want to go to and returns the selected floor as an integer.
        /// </summary>
        /// <param name="currentFloor">The current floor of the elevator.</param>
        /// <param name="elevator">The elevator that the user is using.</param>
        /// <returns>The selected destination floor as an integer.</returns>
        public static int GetDestinationFloor(int currentFloor, Elevator elevator)
        {
            int destinationFloor;

            do
            {
                Console.WriteLine($"Elevator {elevator.Id} is now at floor {elevator.CurrentFloor}.");
                Console.WriteLine($"Please select the floor that you are going to (current floor: {currentFloor}):");
                string destinationFloorInput = Console.ReadLine();

                bool isDestinationFloorValid = int.TryParse(destinationFloorInput, out destinationFloor) && destinationFloor >= 1 && destinationFloor <= elevator.MaxFloor;

                if (!isDestinationFloorValid)
                {
                    Console.WriteLine($"Invalid destination floor. Please enter a number between 1 and {elevator.MaxFloor}.");
                }
            } while (destinationFloor < 1 || destinationFloor > elevator.MaxFloor);

            elevator.DestinationFloor = destinationFloor;
            return destinationFloor;
        }

        /// <summary>
        /// Prompts the user to input a positive integer value and returns the value as an integer.
        /// </summary>
        /// <param name="prompt">The prompt message to display to the user.</param>
        /// <returns>The user input value as an integer.</returns>
        private static int GetPositiveIntegerInput(string prompt)
        {
            int value = 0;

            while (value <= 0)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    value = 0;
                }
            }

            return value;
        }
    }
}
