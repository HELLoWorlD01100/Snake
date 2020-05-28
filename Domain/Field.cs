using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake.Domain
{
    public class Field
    {
        public int Width { get; }
        public int Height { get; }
        public Snake Snake { get; }
        public Point Fruit { get; private set; }
        public HashSet<Point> WallSet { get; }
        public Point ExtraFruit { get; private set; }
        public int CurrentNumberEatenFruits { get; private set; }
        public event Action<int> ScoreChanged;
        public static int GlobalScore { get;  set; }
        public int MinNumberEatenFruit { get; }
        private List<Point> FreeCoordinates;
        private Random random = new Random();
        public event Action Updated;
        private int _numberMove;

        public Field(int width, int height, Point spawnPoint, int minNumberEatenFruit, HashSet<Point> wallList)
        {
            Width = width;
            Height = height;
            Snake = new Snake(spawnPoint);
            WallSet = wallList;
            FreeCoordinates = new List<Point>();
            MinNumberEatenFruit = minNumberEatenFruit;
            UpdateFreeCoordinates();
            if (FreeCoordinates.Count != 0)
                SpawnNewFruit();
        }

        public bool IsGameOver()
        {
            var head = Snake.Body[0];
            var offset = GetOffset();
            var nextCoordinate = new Point(head.X + offset.X, head.Y + offset.Y);
            for (var i = 1; i < Snake.Body.Count - 1; i++)
            {
                if (Snake.Body[i].Equals(nextCoordinate))
                    return true; // лол хз, он если просто возвращать не работает.
            }
            return (nextCoordinate.X > Width - 1 || nextCoordinate.Y > Height - 1 || nextCoordinate.X < 0 ||
                    nextCoordinate.Y < 0 || WallSet.Contains(nextCoordinate));
        }

        private void UpdateFreeCoordinates()
        {
            FreeCoordinates = new List<Point>();
            for (var i = 0; i < Width; i++)
                for (var j = 0; j < Height; j++)
                {
                    var currentPoint = new Point(i, j);
                    if (Snake.Body.Contains(currentPoint) || WallSet.Contains(currentPoint))
                        continue;
                    FreeCoordinates.Add(currentPoint);
                }
        }
        public void SnakeEatFruit()
        {
            if (Snake.Body[0].Equals(Fruit))
            {
                CurrentNumberEatenFruits++;
                GlobalScore += 10;
                ScoreChanged?.Invoke(GlobalScore);
                if (CurrentNumberEatenFruits >= MinNumberEatenFruit && Snake.Body.Count >= MinNumberEatenFruit - 1)
                    ExtraFruit = GetRandomFreePoint();
                Snake.Increase();
                UpdateFreeCoordinates();
                SpawnNewFruit();
                _numberMove = 0;
            }
        }

        public bool SnakeEatExtraFruit()
        {
            return ExtraFruit.Equals(Snake.Body[0]) && CurrentNumberEatenFruits >= MinNumberEatenFruit;
        }

        private Point GetRandomFreePoint()
        {
            var number = random.Next(0, FreeCoordinates.Count - 1);
            return new Point(FreeCoordinates[number].X, FreeCoordinates[number].Y);
        }

        private void SpawnNewFruit()
        {
            Fruit = GetRandomFreePoint();
        }
        public void MoveSnake()
        {
            for (var i = Snake.Body.Count - 1; i >= 1; i--)
            {
                var point = new Point(Snake.Body[i - 1].X, Snake.Body[i - 1].Y);
                Snake.Body[i] = point;
            }
            var offset = GetOffset();
            Snake.Body[0] = new Point(Snake.Body[0].X + offset.X, Snake.Body[0].Y + offset.Y);
            UpdateFreeCoordinates();
            _numberMove += 1;
            if (_numberMove == 20)
            {
                Snake.Reduce();
                SpawnNewFruit();
                _numberMove = 0;
            }
            Updated?.Invoke();
        }

        private Point GetOffset()
        {
            var result = new Point(0, 0);
            switch (Snake.Direction)
            {
                case Direction.Up:
                    result.Y -= 1;
                    break;
                case Direction.Down:
                    result.Y += 1;
                    break;
                case Direction.Left:
                    result.X -= 1;
                    break;
                case Direction.Right:
                    result.X += 1;
                    break;
            }
            return result;
        }
        public void FieldControl_KeyDown(object s, KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.W:
                    Snake.ChangeDirection(Direction.Up);
                    break;
                case Keys.S:
                    Snake.ChangeDirection(Direction.Down);
                    break;
                case Keys.A:
                    Snake.ChangeDirection(Direction.Left);
                    break;
                case Keys.D:
                    Snake.ChangeDirection(Direction.Right);
                    break;
            }
        }
    }
}
