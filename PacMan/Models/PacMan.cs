using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.enums;
using PacMan.interfaces;
using PacMan.settings;
using static System.Console;

namespace PacMan.Models
{
    public class Pacman : Pixel, IMoveble
    {
        public Pacman(int x, int y, ConsoleColor color) : base(x, y, color) 
        {

        }

        public Direction InitialDirection = Direction.Right;
        public int CountCoins { get; private set; }

        public void Move(Direction direction)
        {
            TakeCoin(this);
            TakeHelper(this);


            if (BeatByCast(this))
            {
                GameCondition.Gameover(this);
            }

            switch (direction) 
            {
                case Direction.Right:
                    Clear(X, Y);
                    X++;
                    break;
                case Direction.Left:
                    Clear(X, Y);
                    X--;
                    break;
                case Direction.Down:
                    Clear(X, Y);
                    Y++;
                    break;
                case Direction.Up:
                    Clear(X, Y);
                    Y--;
                    break;
            }
            Draw(X, Y);
        }

        private void TakeCoin(Pixel pacman)
        {
            var removecoin = Coins.coins.FirstOrDefault(coin => coin.X == pacman.X && coin.Y == pacman.Y);
            if (removecoin != null)
            {
                CountCoins++;
                Coins.coins.Remove(removecoin);
                removecoin.Clear(removecoin.X, removecoin.Y);
            }
            return;
        }

        public void TakeHelper(Pixel pacman)
        {
            var help = Helper.helpers.FirstOrDefault(helper => helper.X == pacman.X && helper.Y == pacman.Y);
            if (help != null) 
            {
                var removeCast = Cast.casts.First();
                Cast.casts.Remove(removeCast);
                removeCast.Clear(removeCast.X, removeCast.Y);
                Helper.helpers.Remove(help);
            }
            return;
        }

        public bool BeatByCast(Pixel pacman)
        {
            if (Cast.casts.Any(cast => cast.X == X && cast.Y == Y))
            {
                return true;
            }
            return false;
        }

        public Direction ReadMovement(Direction currentDirrection)
        {
            if (!KeyAvailable)
            {
                return currentDirrection;
            }
            ConsoleKey key = ReadKey(true).Key;
            currentDirrection = key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow =>  Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => currentDirrection
            };
            return currentDirrection;
        }


    }
}
