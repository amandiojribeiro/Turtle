using NUnit.Framework;
using Turtle.Application;
using Turtle.Model;

namespace UnitTest
{
    public class UnitTest
    {
        [Test]
        public void TestCoordinate()
        {
            Coordinate c = new Coordinate { X = 10, Y = 5 };
            Assert.AreEqual(5, c.Y);
        }

        [Test]
        public void TestObserver()
        {
            var observer = new Observer(new Board(10, 6));
            Assert.AreEqual(false, observer.IsDanger(new Coordinate { X = 5, Y = 5 }));
        }

        [Test]
        public void TestTurtle()
        {
            var turtle = Turtle.Model.Turtle.Instance(new Coordinate { X = 5, Y = 6 });
            var positionX = turtle.Position.X;
            var positionY = turtle.Position.Y;
            Assert.AreEqual(positionX, 5);
            Assert.AreEqual(positionY, 6);
        }
    }
}