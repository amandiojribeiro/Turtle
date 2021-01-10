using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using Turtle.Model;
using Turtle.Model.Enums;

namespace Turtle.Application
{
    public class Game
    {
        private readonly Board _board;
        private readonly Observer _observer;
        private readonly Settings _settings;


        public Game()
        {
            _settings = GetSettings();
            _board = new Board(_settings.BoardSizeY, _settings.BoardSizeX);
            _observer = new Observer(_board);
            _board[_settings.TurtleStart] = Turtle.Model.Turtle.Instance(_settings.TurtleStart);
            _board[_settings.Exit] = new Exit() { Position = _settings.Exit };
            foreach (var mine in _settings.Mines)
            {
                _board[mine] = new Mine() { Position = mine };
            }
        }

        public void Start()
        {
            var moves = _settings.Moves;
            var turtle = _board[_settings.TurtleStart] as Turtle.Model.Turtle;
            turtle.Direction = _settings.InitialDirection;

            foreach(var move in moves)
            {
                if (move == "r") turtle.Rotate();
                else if (move == "m") turtle.Move();
                Thread.Sleep(1000);

                var situation = _observer.Observe(turtle.Position);
                if (situation == State.IsDead)
                {
                    Console.WriteLine("The trutle died!!!");
                    break;
                }
                else if (situation == State.IsExit)
                {
                    Console.WriteLine("The trutle exited!!!");
                    break;
                }
                else if (situation == State.IsOutOfBounds)
                {
                    Console.WriteLine("The trutle is out of bounds!!!");
                }
                else if (situation == State.IsDanger)
                {
                    Console.WriteLine("The trutle is in danger!!!");
                }
                else if (situation == State.Normal)
                {
                    Console.WriteLine($"Turtle is in X:{turtle.Position.X} Y:{turtle.Position.Y}");
                }
            }

            Console.WriteLine("Game Ended");
        }

        private Settings GetSettings()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            using StreamReader r = new StreamReader($"{path}\\initialize.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<Settings>(json);
        }
    }
}
