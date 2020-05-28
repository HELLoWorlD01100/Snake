using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Domain
{
    public class Level
    {
        public Point SpawnPoint { get; }
        public HashSet<Point> WallSet { get; }
        public int Width { get; }
        public int Height { get; }
        public int MinScore { get; }

        public Level(Point spawnPoint, HashSet<Point> Walls, int width, int height, int minScore)
        {
            SpawnPoint = spawnPoint;
            WallSet = Walls;
            Width = width;
            Height = height;
            MinScore = minScore;
            if (WallSet.Contains(spawnPoint) || WallSet.Contains(new Point(spawnPoint.X - 1, spawnPoint.Y)))
                throw new InvalidOperationException("Координаты для спавна заданы неправильно!");
            if (!IsCorrectLevel())
                throw new  InvalidOperationException("Змейка не имеет доступ ко всему полю!");
        }

        private bool IsCorrectLevel()
        {
            var result = new HashSet<Point>();
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    var finishPoint = new Point(i, j);
                    if (WallSet.Contains(finishPoint))
                        continue;
                    var visited = new HashSet<Point>();
                    var queue = new Queue<Point>();
                    queue.Enqueue(SpawnPoint);
                    while (queue.Count != 0)
                    {
                        var point = queue.Dequeue();
                        if (point.X < 0 || point.X > Width - 1 || point.Y < 0 || point.Y > Height - 1)
                            continue;
                        if (WallSet.Contains(point) || visited.Contains(point))
                            continue;
                        visited.Add(point);
                        if (point.Equals(finishPoint))
                        {
                            result.Add(point);
                            break;
                        }

                        for (var dx = -1; dx <= 1; dx++)
                            for (var dy = -1; dy <= 1; dy++)
                            {
                                if (Math.Abs(dx) == Math.Abs(dy))
                                    continue;
                                var nextPoint = new Point(point.X + dx, point.Y + dy);
                                queue.Enqueue(nextPoint);
                            }
                    }
                }
            }
            return Width * Height - WallSet.Count == result.Count;
        }
    }
}
