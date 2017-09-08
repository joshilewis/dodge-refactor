using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace FormApp
{
    public partial class RainDodge : Form
    {
        private readonly Game game;
        private bool gameRunning = false;

        public RainDodge()
        {
            InitializeComponent();
            game = new Game(GameOver, Size);
        }

        private void GameOver()
        {
            gameRunning = false;
        }

        private void RainDodge_KeyDown(object sender, KeyEventArgs e)
        {
            RunGame();
        }

        private void RunGame()
        {
            game.StartGame();
            gameRunning = true;
            while (gameRunning)
            {
                game.Tick();
                DrawComponents();
                Invalidate();
                Thread.Sleep(1000/30);
            }
        }

        private void DrawComponents()
        {
            var formGraphics = CreateGraphics();
            formGraphics.Clear(Color.White);
            DrawPlayer(formGraphics);
            DrawDrops(formGraphics);
            formGraphics.Dispose();
        }

        private void DrawPlayer(Graphics formGraphics)
        {
            SolidBrush redBrush = new SolidBrush(Color.Red);
            formGraphics.FillRectangle(redBrush, game.PlayerBounds);
            redBrush.Dispose();
        }

        private void DrawDrops(Graphics formGraphics)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            foreach (var dropBound in game.DropBounds)
            {
                formGraphics.FillRectangle(blueBrush, dropBound);
            }
            blueBrush.Dispose();
        }
    }
}
