using ElevatorChallenge;

var building = UserInput.InitializeElevatorSystem();

while (true)
{
    building.DisplayElevatorStatus();

    var floorNum = UserInput.GetFloorNumber(building.TopFloor);

    var people = UserInput.GetNumPeopleWaiting(building.ElevatorSizeLimit);

    var elevator = building.GetNearestElevator(floorNum, people);

    ElevatorSimulation.SimulateElevatorMovement(elevator, building.DisplayElevatorStatus);

    var distinationFloor = UserInput.GetDestinationFloor(floorNum, elevator);

    elevator.NumberOfPeopleInside = people;

    ElevatorSimulation.SimulateElevatorMovement(elevator, building.DisplayElevatorStatus);

    Console.WriteLine("Simulation completed, press any key to run again or 'q' to quit...");

    var userChoice = Console.ReadLine();

    if (userChoice == "q")
    {
        break;
    }

    Console.Clear();
}







