namespace MarsRoverController
{
    class EarthControlCenter
    {
        static void Main(string[] args)
        {
            Mars mars = new Mars();
            Console.WriteLine("Mars Rovers Control Center");
            Console.WriteLine("Commands: Add Rover <X> <Y> <Direction>, Remove <ID>, Move <ID>, Turn Left <ID>, Turn Right <ID>, Display Rovers, Exit");

            string? input = "";
            while (input != "Exit")
            {
                Console.WriteLine("Enter command:");
                try
                {
                    input = Console.ReadLine();

                    if (input == null || input == "")
                    {
                        break;
                    }

                    string[] parts = input.Split(' ');

                    ControlCenterCommands command = (ControlCenterCommands)Enum.Parse(typeof(ControlCenterCommands), parts[0]);

                    if (command == ControlCenterCommands.Exit) break;


                    switch (command)
                    {
                        case ControlCenterCommands.Add:
                            if (parts[1] == "Rover" && parts.Length == 5)
                            {
                                int x = int.Parse(parts[2]);
                                int y = int.Parse(parts[3]);
                                //System.Globalization.CultureInfo.CurrentCulture is being used to obtain the culture-specific information, specifically the current culture of the system.
                                Directions direction = (Directions)Enum.Parse(typeof(Directions), parts[4].ToUpper(System.Globalization.CultureInfo.CurrentCulture));

                                mars.AddRover(x, y, direction);
                            }
                            else
                            {
                                throw new InvalidOperationException("Invalid command format");
                            }
                            break;
                        case ControlCenterCommands.Move:
                            if (parts.Length == 2)
                            {
                                int roverId = int.Parse(parts[1]);

                                mars.ExecuteCommand(roverId, RoverCommands.Move);
                            }
                            else
                            {
                                throw new InvalidOperationException("Invalid command format");
                            }
                            break;
                        case ControlCenterCommands.Turn:
                            if (parts.Length == 3)
                            {
                                int roverId = int.Parse(parts[2]);
                                RoverCommands roverCommand =
                                    (RotationDirection)Enum.Parse(typeof(RotationDirection), parts[1]) == RotationDirection.Right ? RoverCommands.TurnRight : RoverCommands.TurnLeft;

                                mars.ExecuteCommand(roverId, roverCommand);
                            }
                            else
                            {
                                throw new InvalidOperationException("Invalid command format");
                            }
                            break;
                        case ControlCenterCommands.Display:
                            mars.DisplayRovers();
                            break;
                        case ControlCenterCommands.Remove:
                            if (parts.Length == 2)
                            {
                                int roverId = int.Parse(parts[1]);

                                mars.RemoveRover(roverId);
                            }
                            else
                            {
                                throw new InvalidOperationException("Invalid command format");
                            }
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command format");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing command: {ex.Message}");
                }
            }
        }
    }
}
