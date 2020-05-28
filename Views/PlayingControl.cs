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

namespace Snake.Views
{
    public partial class PlayingControl : UserControl
    {
        private Game _game;
        private Timer timer = new Timer() {Interval = 300};
        public PlayingControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            _game = game;
            _game.Field.ScoreChanged += ChangeScoreBoard;
            fieldControl1.Configure(_game.Field);
            timer.Tick += Game_Process;
            timer.Start();
            
        }
        
        public void Game_Process(object s, EventArgs e)
        {
            if (!_game.Field.IsGameOver())
            {
                _game.Field.SnakeEatFruit();
                _game.Field.MoveSnake();
                if (_game.Field.SnakeEatExtraFruit())
                {
                    timer.Tick -= Game_Process;
                    timer.Stop();
                    _game.Start();
                }
            }
            else
            {
                timer.Tick -= Game_Process;
                timer.Stop();
                _game.ChangeStage(GameStage.Finished);
                ScoreBoard.Text = ("Счёт: 0");
            }
        }

        public void ChangeScoreBoard(int score)
        {
            ScoreBoard.Text = ($"Счёт: {score}");
        }
    }
}
