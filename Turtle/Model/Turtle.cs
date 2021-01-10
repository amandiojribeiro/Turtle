using Turtle.Model.Enums;

namespace Turtle.Model
{
    public class Turtle : Element
    {

        private static Turtle _turtle;

        private Turtle(Coordinate position) { Position = position; }

        public static Turtle Instance(Coordinate position)
        {
            return _turtle ??= new Turtle(position);
        }

        public Direction Direction { get; set; }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    _turtle.Position = new Coordinate { X = _turtle.Position.X - 1, Y = _turtle.Position.Y };
                    break;
                case Direction.South:
                    _turtle.Position = new Coordinate { X = _turtle.Position.X + 1, Y = _turtle.Position.Y };
                    break;
                case Direction.East:
                    _turtle.Position = new Coordinate { X = _turtle.Position.X, Y = _turtle.Position.Y + 1 };
                    break;
                case Direction.West:
                    _turtle.Position = new Coordinate { X = _turtle.Position.X, Y = _turtle.Position.Y - 1 };
                    break;
            }
        }

        public void Rotate()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
                default:
                    break;
            }
        }
    }
}
