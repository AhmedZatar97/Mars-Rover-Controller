namespace MarsRoverController
{
    public class Mars : IPlanet
    {
        private Dictionary<int, Rover> rovers = new Dictionary<int, Rover>();
        private int nextRoverId = 1;
        private (int, int) edge = (-100, 100);
        private bool[,] grid;

        public Mars()
        {
            int gridSize = edge.Item2 - edge.Item1 + 1;
            grid = new bool[gridSize, gridSize];
        }


        public void AddRover(int x, int y, Directions direction)
        {
            CheckSpaceAvailability(x, y);

            Rover newRover = new Rover(nextRoverId, (x, y), direction);
            rovers.Add(nextRoverId, newRover);
            grid[x - edge.Item1, y - edge.Item1] = true;
            Console.WriteLine(newRover);
            nextRoverId++;
        }

        public void RemoveRover(int roverId)
        {
            if (rovers.TryGetValue(roverId, out Rover? roverToRemove))
            {
                rovers.Remove(roverToRemove.ID);
                Console.WriteLine($"Rover with ID {roverToRemove.ID} has been removed");
            }
            else
            {
                throw new InvalidOperationException($"No rover with ID {roverId} found");
            }

        }


        public void ExecuteCommand(int roverId, RoverCommands command)
        {

            if (rovers.TryGetValue(roverId, out Rover? rover))
            {
                switch (command)
                {
                    case RoverCommands.Move:
                        (int newX, int newY) = rover.NewCoordinates;

                        CheckSpaceAvailability(newX, newY);

                        grid[rover.Coordinates.X - edge.Item1, rover.Coordinates.Y - edge.Item1] = false;
                        rover.Move();
                        grid[newX - edge.Item1, newY - edge.Item1] = true;

                        break;
                    case RoverCommands.TurnRight:
                        rover.TurnRight();
                        break;
                    case RoverCommands.TurnLeft:
                        rover.TurnLeft();
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

                Console.WriteLine(rover);
            }
            else
            {
                throw new InvalidOperationException($"No rover with ID {roverId} found");
            }

        }

        public void DisplayRovers()
        {
            foreach (Rover rover in rovers.Values)
            {
                Console.WriteLine(rover);
            }
        }

        private void CheckSpaceAvailability(int x, int y)
        {

            if (!(x >= edge.Item1 && x <= edge.Item2 && y >= edge.Item1 && y <= edge.Item2))
            {
                throw new InvalidOperationException("Rover coordinates are out of bounds");
            }
            else if (grid[x - edge.Item1, y - edge.Item1])
            {
                throw new InvalidOperationException("Two rovers cannot be in the same place");
            }
        }
    }
}
