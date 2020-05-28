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
    public partial class FinishedControl : UserControl
    {
        private Game game;
        public FinishedControl()
        {
            InitializeComponent();
        }
        public void Configure(Game game)
        {
            this.game = game;
            game.Win += ChangeText;
            label1.Text = $@"Ваш счёт: {Field.GlobalScore}";
        }

        private void ChangeText()
        {
            label2.Text = $"Вы просто супер!";
            label3.Text = $"Победа!";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Field.GlobalScore = 0;
            game.Restart();
        }
    }
}
