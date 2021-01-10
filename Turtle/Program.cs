using System.Threading;
using Turtle.Application;

namespace Turtle
{
    class Program
    {
        static void Main()
        {
            var game = new Game();
            game.Start();
            Thread.Sleep(60000);
            System.Console.ReadKey();
        }
    }
}
