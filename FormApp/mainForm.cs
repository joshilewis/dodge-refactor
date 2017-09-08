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
            Size = new Size(600, 400);
            game = new Game(GameOver, Size);
        }

        private void GameOver()
        {
            gameRunning = false;
            var formGraphics = CreateGraphics();
            formGraphics.Clear(Color.White);
            formGraphics.DrawString("Game Over :(", new Font("Arial", 40), Brushes.Black, Width / 2, Height / 2);
            formGraphics.Dispose();

        }

        private void RainDodge_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode.ToString());
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (!gameRunning)
                        RunGame();
                    break;
                case Keys.Left:
                    game.MovePlayerLeft();
                    break;
                case Keys.Right:
                    game.MovePlayerRight();
                    break;
            }
        }

        private void RunGame()
        {
            game.StartGame();
            gameRunning = true;
            while (gameRunning)
            {
                DrawComponents();
                Invalidate();
                Thread.Sleep(1000/30);
                game.Tick();
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

        private void RainDodge_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (!gameRunning)
                        RunGame();
                    break;
                case Keys.Left:
                    game.MovePlayerLeft();
                    break;
                case Keys.Right:
                    game.MovePlayerRight();
                    break;
            }

        }
    }
}
