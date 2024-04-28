namespace MarsRoverController
{
    public interface IPlanet
    {
        public void AddRover(int x, int y, Directions direction);
        public void RemoveRover(int roverId);
        public void ExecuteCommand(int roverId, RoverCommands command);
        public void DisplayRovers();
    }
}
