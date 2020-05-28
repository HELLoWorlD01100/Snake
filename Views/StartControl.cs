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
    public partial class StartControl : UserControl
    {
        private Game game;
        public StartControl()
        {
            InitializeComponent();
        }
        public void Configure(Game game)
        {
            this.game = game;
            StartButton.Click += StartButton_Click;
        }

        public void StartButton_Click(object sender, EventArgs e)
        {
            game.Start();
        }
    }
}
