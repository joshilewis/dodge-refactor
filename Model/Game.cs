﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Game
    {
        private const int TotalNumberOfDrops = 20;
        private const int MaxFallDistance = 10;

        private readonly Player player;
        private readonly List<Drop> drops;
        private readonly Action gameOver;
        private readonly Size boardSize;
        private readonly Random random;

        public Game(Action gameOver, Size boardSize)
        {
            this.gameOver = gameOver;
            this.boardSize = boardSize;
            player = new Player(10, 10, boardSize.Width / 2, boardSize.Height - 50);
            drops = new List<Drop>(TotalNumberOfDrops);
            random=new Random();
        }

        public void StartGame()
        {
            GenerateDrops(TotalNumberOfDrops);
        }

        private void GenerateDrops(int numberOfDropsToGenerate)
        {
            for (var i = 0; i < numberOfDropsToGenerate; i++)
            {
                int randomX = random.Next(boardSize.Width);
                drops.Add(new Drop(5, 5, randomX, 2));
            }
        }

        public void Tick()
        {
            drops.ForEach(x => x.MoveDown(random.Next(MaxFallDistance)));

            if (drops.Any(x => x.IntersectsWith(player)))
            {
                GameOver();
            }

            int numberOfNewDrops = drops.RemoveAll(x => x.HasDroppedOffTheBottom(boardSize));
            GenerateDrops(numberOfNewDrops);
        }

        private void GameOver()
        {
            gameOver.Invoke();
        }

        public Rectangle PlayerBounds
        {
            get { return player.Bounds; }
        }

        public IEnumerable<Rectangle> DropBounds
        {
            get { return drops.Select(x => x.Bounds); }
        }

        public void MovePlayerRight()
        {
            player.MoveRight();
        }
        public void MovePlayerLeft()
        {
            player.MoveLeft();
        }

    }
}
