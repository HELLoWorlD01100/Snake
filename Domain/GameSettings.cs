using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Domain
{
    public class GameSettings
    {
        public Queue<Level> Levels { get; } = new Queue<Level>();

        private HashSet<Point> _wallsLevel1 = new HashSet<Point>();
        private HashSet<Point> _wallsLevel2 = new HashSet<Point>()
        {
            new Point(1,2), new Point(1, 3), new Point(1, 4), new Point(1, 5), new Point(1, 6), new Point(1, 7),
            new Point(3,2), new Point(3,3), new Point(3,4), new Point(3,5), new Point(3,6), new Point(3,7),
            new Point(4,4), new Point(4,5), new Point(5,4), new Point(5,5),
            new Point(6,2), new Point(6,3), new Point(6,4), new Point(6,5), new Point(6,6), new Point(6,7),
            new Point(8,2), new Point(8, 3), new Point(8, 4), new Point(8, 5), new Point(8, 6), new Point(8, 7),
        };

        private HashSet<Point> _wallsLevel3 = new HashSet<Point>()
        {
            new Point(1,1), new Point(1,2), new Point(8, 1), new Point(8,2),
            new Point(4,2), new Point(5,2), new Point(0,4), new Point(1,4),
            new Point(8,4), new Point(8,4), new Point(1,7), new Point(1,8),
            new Point(4,7), new Point(4,8), new Point(8,7), new Point(8,8),
            new Point(9,4), new Point(5,7), new Point(5,8), new Point(4,1),new Point(5,1)
        };
        private HashSet<Point> _wallsLevel4 = new HashSet<Point>()
        {
            new Point(1,1), new Point(1,3), new Point(1,5), new Point(1,7), new Point(1,9),
            new Point(3,1), new Point(3,3), new Point(3,5), new Point(3,7), new Point(3,9),
            new Point(5,1), new Point(5,3), new Point(5,5), new Point(5,7), new Point(5,9),
            new Point(7,1), new Point(7,3), new Point(7,5), new Point(7,7), new Point(7,9),
            new Point(9,1), new Point(9,3), new Point(9,5), new Point(9,7), new Point(9,9)
        };
        private HashSet<Point> _wallsLevel5 = new HashSet<Point>()
        {
            new Point(2,2), new Point(3,2), new Point(4,2), new Point(5,2), new Point(6,2),
            new Point(4,3), new Point(4,4), new Point(4,5), new Point(4,6), new Point(4,7), 
            new Point(4,8)
        };
        private HashSet<Point> _wallsLevel6 = new HashSet<Point>()
        {
            new Point(0, 0),new Point(0,9), new Point(9,9), new Point(9,0), new Point(2,3), 
            new Point(3,3), new Point(4,3), new Point(5,3), new Point(6,3), new Point(2,6), 
            new Point(3,6), new Point(4,6), new Point(5,6), new Point(6,6), new Point(7,3),
            new Point(7,6)
        };
        private HashSet<Point> _wallsLevel7 = new HashSet<Point>()
        {
            new Point(1,1), new Point(1,2), new Point(1,3), new Point(1,4), new Point(1,5), 
            new Point(1,6), new Point(1,7), new Point(1,8), new Point(2,1), new Point(2,8), 
            new Point(3,1), new Point(3,3), new Point(3,6), new Point(3,8), new Point(4,3), 
            new Point(4,6), new Point(5,3), new Point(5,6), new Point(6,1), new Point(6,3), 
            new Point(6,6), new Point(6,8), new Point(7,1), new Point(7,8), new Point(8,1), 
            new Point(8,2), new Point(8,3), new Point(8,4), new Point(8,5), new Point(8,6), 
            new Point(8,7), new Point(8,8)
        };
        public GameSettings()
        {
            CreateLevels();
        }
        public Field CreateField(Level level)
        {
            return new Field(level.Width, level.Height, level.SpawnPoint, level.MinScore, level.WallSet);
        }

        private void CreateLevels()
        {
            Levels.Enqueue(new Level(new Point(1, 1), _wallsLevel1, 10, 10, 10));
            Levels.Enqueue(new Level(new Point(1, 1), _wallsLevel2, 10, 10, 7));
            Levels.Enqueue(new Level(new Point(3, 0), _wallsLevel3, 10, 10, 7));
            Levels.Enqueue(new Level(new Point(1, 2), _wallsLevel4, 11, 11,8));
            Levels.Enqueue(new Level(new Point(2,1), _wallsLevel5, 9, 10,7));
            Levels.Enqueue(new Level(new Point(2, 2), _wallsLevel6, 10, 10,7));
            Levels.Enqueue(new Level(new Point(1,0), _wallsLevel7, 10,10,7));
        }
    }
}
