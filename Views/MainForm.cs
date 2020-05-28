using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake.Domain;

namespace Snake.Views
{
    public partial class MainForm : Form
    {
        private Game game;

        public MainForm()
        {
            game = new Game();
            game.StageChanged += Game_OnStageChanged;
            InitializeComponent();
            ShowStartScreen();
        }
        private void Game_OnStageChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.NotStarted:
                    ShowStartScreen();
                    break;
                case GameStage.Playing:
                    ShowPlayingScreen();
                    break;
                case GameStage.Finished:
                    ShowFinishedScreen();
                    break;
                
            }
        }
        private void ShowStartScreen()
        {
            HideScreens();
            startControl.Configure(game);
            startControl.Show();
        }



        private void ShowPlayingScreen()
        {
            HideScreens();
            playingControl.Configure(game);
            playingControl.Show();
            playingControl.Focus();
        }

        private void ShowFinishedScreen()
        {
            HideScreens();
            finishedControl.Configure(game);
            finishedControl.Show();
        }

        private void HideScreens()
        {
            startControl.Hide();
            playingControl.Hide();
            finishedControl.Hide();
        }
    }
}
