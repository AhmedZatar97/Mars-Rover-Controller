namespace MarsRoverController
{
    public class Rover
    {
        private Directions direction;
        public int ID { get; private set; }
        public (int X, int Y) Coordinates { get; private set; }

        public Rover(int id, (int, int) firstCoords, Directions firstDirection)
        {
            ID = id;
            Coordinates = firstCoords;
            direction = firstDirection;
        }

        public (int, int) NewCoordinates
        {
            get
            {

                (int, int) newCoordinates = Coordinates;

                switch (direction)
                {
                    case Directions.N:
                        newCoordinates = (Coordinates.X, Coordinates.Y + 1);
                        break;
                    case Directions.E:
                        newCoordinates = (Coordinates.X + 1, Coordinates.Y);
                        break;
                    case Directions.S:
                        newCoordinates = (Coordinates.X, Coordinates.Y - 1);
                        break;
                    case Directions.W:
                        newCoordinates = (Coordinates.X - 1, Coordinates.Y);
                        break;
                }

                return newCoordinates;
            }
        }

        public void Move() => Coordinates = NewCoordinates;

        public void TurnRight()
        {
            switch (direction)
            {
                case Directions.N:
                    direction = Directions.E;
                    break;
                case Directions.E:
                    direction = Directions.S;
                    break;
                case Directions.S:
                    direction = Directions.W;
                    break;
                case Directions.W:
                    direction = Directions.N;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (direction)
            {
                case Directions.N:
                    direction = Directions.W;
                    break;
                case Directions.E:
                    direction = Directions.N;
                    break;
                case Directions.S:
                    direction = Directions.E;
                    break;
                case Directions.W:
                    direction = Directions.S;
                    break;
            }
        }

        public override string ToString()
        {
            return $"Rover {ID} is at {Coordinates} with {direction} direction";
        }
    }
}
