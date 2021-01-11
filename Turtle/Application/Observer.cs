using System.Collections.Generic;
using System.Linq;
using Turtle.Model;
using Turtle.Model.Enums;

namespace Turtle.Application
{
    public class Observer
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Board _board;

        public Observer(Board board)
        {
            _width = board.Width;
            _height = board.Height;
            _board = board;
        }

        public State Observe(Coordinate position)
        {
            if (!IsInBounds(position)) return State.IsOutOfBounds;
            else if (IsDead(position)) return State.IsDead;
            else if (IsDanger(position)) return State.IsDanger;
            else if (IsExit(position)) return State.IsExit;
            else return State.Normal;
        }

        public bool IsDanger(Coordinate position)
        {
            var adjacentPoints = GetAdjacentPositions(position);
            return adjacentPoints.Any(x => _board[position] is Mine);
        }

        private bool IsDead(Coordinate position)
        {
            return _board[position] is Mine;
        }

        private bool IsInBounds(Coordinate c)
        {
            return _board.Elements.ContainsKey($"{c.X}{c.Y}");
        }

        private bool IsExit(Coordinate position)
        {
            return _board[position] is Exit;
        }

        private List<Coordinate> GetAdjacentPositions(Coordinate position)
        {
            var list = new List<Coordinate>();

            if (position.X - 1 >= 0) list.Add(new Coordinate { X = position.X - 1, Y = position.Y });
            if (position.X - 1 >= 0 && position.Y - 1 >= 0) list.Add(new Coordinate { X = position.X - 1, Y = position.Y - 1 });
            if (position.X - 1 >= 0 && position.Y + 1 < _width) list.Add(new Coordinate { X = position.X - 1, Y = position.Y + 1 });
            if (position.X + 1 < _height) list.Add(new Coordinate { X = position.X + 1, Y = position.Y });
            if (position.X + 1 < _height && position.Y - 1 >= 0) list.Add(new Coordinate { X = position.X + 1, Y = position.Y - 1 });
            if (position.X + 1 < _height && position.Y + 1 < _width) list.Add(new Coordinate { X = position.X + 1, Y = position.Y + 1 });
            if (position.Y - 1 >= 0) list.Add(new Coordinate { X = position.X, Y = position.Y - 1 });
            if (position.Y + 1 < _width) list.Add(new Coordinate { X = position.X, Y = position.Y + 1 });

            return list;
        }
    }
}
