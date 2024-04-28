using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.enums;
using PacMan.interfaces;
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
            if (TakeCoin(this))
            {
                CountCoins++;
            }

            if (BeatByCast(this))
            {
                GameSettings.Gameover(this);
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

        private bool TakeCoin(Pixel pacman)
        {

            if(Coins.coins.Any(coin => coin.X == pacman.X && coin.Y == pacman.Y))
            {
                return true;
            }

            return false;
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
