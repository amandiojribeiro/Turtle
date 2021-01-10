using System.Collections.Generic;


namespace Turtle.Model
{
    public class Board
    {
        public Dictionary<string, Element> Elements { get; }

        public int Width { get; private set; }
        public int Height { get; private set; }


        public Board(int x, int y)
        {
            Width = y;
            Height = x;

            Elements = new Dictionary<string, Element>();

            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= y; j++)
                {
                    Elements.Add($"{i}{j}" , null);
                }
            }
        }

        public Element this[Coordinate c]
        {
            get 
            { 
                return Elements[$"{c.X}{c.Y}"]; 
            }
            set 
            { 
                Elements[$"{c.X}{c.Y}"] = value; 
            }
        }

    }
}
