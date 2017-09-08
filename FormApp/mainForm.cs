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
        private bool gameRunning;
        private bool gameHasEnded;

        public RainDodge()
        {
            InitializeComponent();
            Size = new Size(600, 400);
            game = new Game(GameOver, Size);
        }

        private void GameOver()
        {
            gameRunning = false;
            gameHasEnded = true;
            lblGameOver.Visible = true;
        }

        private void RainDodge_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode.ToString());
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (!gameHasEnded)
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
            lblSpaceToStart.Visible = false;
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

        private void DoWithGraphics(Action<Graphics> action)
        {
            var formGraphics = CreateGraphics();
            action(formGraphics);
            formGraphics.Dispose();
        }

        private void DrawComponents()
        {
            DoWithGraphics(x =>
            {
                x.Clear(Color.White);
                DrawPlayer(x);
                DrawDrops(x);

            });
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
