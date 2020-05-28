using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake.Domain;
using Snake.Properties;

namespace Snake.Views
{
    public partial class FieldControl : UserControl
    {
        private Field _field;
        private Dictionary<Point, Rectangle> pointToRectangle;
        private int snakeLenght;
        private readonly Image fruit = (Image)Resources.ResourceManager.GetObject("fruit");
        private readonly Image grass = (Image)Resources.ResourceManager.GetObject("grass");
        private readonly Image wall = (Image)Resources.ResourceManager.GetObject("wall");
        private readonly Image extraFruit = (Image)Resources.ResourceManager.GetObject("extrafruit");
        private Image snakeHead;
        private Image snakeBody;
        private Image snakeTail;
        private Image turnBody;
        public FieldControl()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        public void Configure(Field field)
        {
            _field = field;
            _field.Updated += Invalidate;
            pointToRectangle = GeneratePointToRectangle(_field, Width, Height);
            KeyDown += _field.FieldControl_KeyDown;
        }

        private static Dictionary<Point, Rectangle> GeneratePointToRectangle(Field field, int width, int height)
        {
            var result = new Dictionary<Point, Rectangle>();
            for (var x = 0; x < field.Width; x++)
            {
                for (var y = 0; y < field.Height; y++)
                {
                    var left = (width - 2) * x / field.Width + 1;
                    var right = (width - 2) * (x + 1) / field.Width + 1;
                    var top = (height - 2) * y / field.Height + 1;
                    var bottom = (height - 2) * (y + 1) / field.Height + 1;
                    var rectangle = new Rectangle(left, top, right - left, bottom - top);
                    result.Add(new Point(x, y), rectangle);
                }
            }
            return result;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            snakeLenght = _field.Snake.Body.Count;
            base.OnPaint(e);
            foreach (var i in pointToRectangle) // трава
                e.Graphics.DrawImage(grass, i.Value);
            foreach (var i in _field.WallSet) // стены
            {
                e.Graphics.DrawImage(wall, pointToRectangle[i]);
            }
            e.Graphics.DrawImage(fruit, pointToRectangle[(Point)_field.Fruit]); // яблоко
            if (_field.CurrentNumberEatenFruits >= _field.MinNumberEatenFruit) // вишенки
                e.Graphics.DrawImage(extraFruit, pointToRectangle[(Point)_field.ExtraFruit]);
            var tailOffset = GetOffset(_field.Snake.Body[snakeLenght - 2], _field.Snake.Body[snakeLenght - 1]);
            switch (tailOffset.X) // хвост
            {
                case -1 when tailOffset.Y == 0:
                    snakeTail = Resources.tailLeft; 
                    break;
                case 1 when tailOffset.Y == 0: 
                    snakeTail = Resources.tailRight;
                    break;
                case 0 when tailOffset.Y == 1:
                    snakeTail = Resources.tailDown;
                    break;
                case 0 when tailOffset.Y == -1: 
                    snakeTail = Resources.tailUp; 
                    break;
            }
            

            e.Graphics.DrawImage(snakeTail, pointToRectangle[_field.Snake.Body[snakeLenght - 1]]);
            switch (_field.Snake.Direction) // голова
            {
                case Direction.Down:
                    snakeHead = Resources.headDown;
                    break;
                case Direction.Up:
                    snakeHead = Resources.headUp;
                    break;
                case Direction.Left:
                    snakeHead = Resources.headLeft;
                    break;
                case Direction.Right:
                    snakeHead = Resources.headRight;
                    break;
            }
            e.Graphics.DrawImage(snakeHead, pointToRectangle[_field.Snake.Body[0]]);
            for (var i = 1; i < snakeLenght - 1; i++) // тело
            {
                var offset = GetOffset(_field.Snake.Body[i - 1], _field.Snake.Body[i]);
                switch (offset.X)
                {
                    case 1 when offset.Y == 0:
                        snakeBody = Resources.bodyRight;
                        break;
                    case -1 when offset.Y == 0:
                        snakeBody = Resources.bodyLeft;
                        break;
                    case 0 when offset.Y == 1:
                        snakeBody = Resources.bodyDown;
                        break;
                    case 0 when offset.Y == -1:
                        snakeBody = Resources.bodyUp;
                        break;
                }
                e.Graphics.DrawImage(snakeBody, pointToRectangle[_field.Snake.Body[i]]);
            }

            for (var i = 1; i < snakeLenght - 1; i++) // повороты
            {
                var mainOffset = GetOffset(_field.Snake.Body[i - 1], _field.Snake.Body[i + 1]);
                var auxiliaryOffset = GetOffset(_field.Snake.Body[i - 1], _field.Snake.Body[i]);
                switch (mainOffset.X)
                {
                    case 1 when mainOffset.Y == 1:
                        switch (auxiliaryOffset.X)
                        {
                            case 1 when auxiliaryOffset.Y == 0:
                                turnBody = Resources.turnUpOrRight;
                                break;
                            case 0 when auxiliaryOffset.Y == 1:
                                turnBody = Resources.turnDownOrLeft;
                                break;
                        }
                        e.Graphics.DrawImage(turnBody, pointToRectangle[_field.Snake.Body[i]]);
                        break;
                    case -1 when mainOffset.Y == -1:
                        switch (auxiliaryOffset.X)
                        {
                            case 0 when auxiliaryOffset.Y == -1:
                                turnBody = Resources.turnUpOrRight;
                                break;
                            case -1 when auxiliaryOffset.Y == 0:
                                turnBody = Resources.turnDownOrLeft;
                                break;
                        }
                        e.Graphics.DrawImage(turnBody, pointToRectangle[_field.Snake.Body[i]]);
                        break;
                    case 1 when mainOffset.Y == -1:
                        switch (auxiliaryOffset.X)
                        {
                            case 1 when auxiliaryOffset.Y == 0:
                                turnBody = Resources.turnDownOrRight;
                                break;
                            case 0 when auxiliaryOffset.Y == -1:
                                turnBody = Resources.turnUpOrLeft;
                                break;
                        }
                        e.Graphics.DrawImage(turnBody, pointToRectangle[_field.Snake.Body[i]]);
                        break;
                    case -1 when mainOffset.Y == 1:
                        switch (auxiliaryOffset.X)
                        {
                            case 0 when auxiliaryOffset.Y == 1:
                                turnBody = Resources.turnDownOrRight;
                                break;
                            case -1 when auxiliaryOffset.Y == 0:
                                turnBody = Resources.turnUpOrLeft;
                                break;
                        }
                        e.Graphics.DrawImage(turnBody, pointToRectangle[_field.Snake.Body[i]]);
                        break;
                }
            }
        }
        private Point GetOffset(Point firstPoint, Point secondPoint)
        {
            return new Point(firstPoint.X - secondPoint.X, firstPoint.Y - secondPoint.Y);
        }
    }
}
