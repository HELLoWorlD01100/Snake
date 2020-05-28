using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Domain
{
    public class Snake
    {
        public Direction Direction { get; private set; } = Direction.Right;
        public  List<Point> Body { get; }

        public Snake(Point head)
        {
            Body = new List<Point>(){head, new Point(head.X - 1, head.Y)};
        }

        public void Increase()
        {
            var tail = new Point(Body.Last().X, Body.Last().Y);
            Body.Add(tail);
        }

        public void Reduce()
        {
            if (Body.Count > 2)
                Body.RemoveAt(Body.Count - 1);
        }
        public void ChangeDirection(Direction direction)
        {
            if (Body.Count <= 1)
                Direction = direction;
            else
            {
                switch (direction)
                {
                    case Direction.Up:
                    case Direction.Down:
                        if (Body[0].X != Body[1].X)
                            Direction = direction;
                        break;
                    case Direction.Left:
                    case Direction.Right:
                        if (Body[0].Y != Body[1].Y)
                            Direction = direction;
                        break;
                }
            }
        }

    }
}
