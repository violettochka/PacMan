using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.enums;
using PacMan.interfaces;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

namespace PacMan.Models
{
    public class Cast : Pixel, IMoveble
    {
        public static List<Cast> casts = new List<Cast>();
        private  ConsoleColor colorCast {  get; set; }
        public Cast(int x, int y, ConsoleColor color, Direction direction) : base(x, y, color)
        {
            InitialDirection = direction;
        }

        public Direction InitialDirection;

        Random random = new Random();

        private bool CanMoveInDirection(Direction direction)
        {
            int nextX = X;
            int nextY = Y;

            switch (direction)
            {
                case Direction.Right:
                    nextX = X + 1;
                    break;
                case Direction.Left:
                    nextX = X - 1;
                    break;
                case Direction.Down:
                    nextY = Y + 1;
                    break;
                case Direction.Up:
                    nextY = Y - 1;
                    break;
            }

            if (nextX >= ConsoleSettings.CONSOLEWIDTH - 1 ||
               nextY >= ConsoleSettings.CONSOLEHEIGTH - 1||
               nextX <= 0 || nextY <= 0 ||
               Wall.walls.Any(w => w.wallelems.Any(el => el.X == nextX && el.Y == nextY)) ||
               Coins.coins.Any(coin => coin.X == nextX && coin.Y == nextY) ||
               Helper.helpers.Any(helper => helper.X ==  nextX && helper.Y == nextY))

            {
                return false; 
            }

            return true;
        }


        public void Move(Direction direction)
        {

            if (!CanMoveInDirection(direction))
            {
                int enumLength = Enum.GetValues(typeof(Direction)).Length;
                int randomIndex;
                do
                {
                    randomIndex = random.Next(0, enumLength);
                } while ((Direction)randomIndex == direction);

                direction = (Direction)randomIndex;
                while(!
                    CanMoveInDirection(direction))
                {
                    randomIndex = random.Next(0, enumLength);

                    direction = (Direction)randomIndex;
                }
            }
                switch (direction)
                {
                    case Direction.Right:
                        Clear(X, Y);
                        X = X + 1;
                        break;
                    case Direction.Left:
                        Clear(X, Y);
                        X = X - 1;
                        break;
                    case Direction.Down:
                        Clear(X, Y);
                        Y = Y + 1;
                        break;
                    case Direction.Up:
                        Clear(X, Y);
                        Y = Y - 1;
                        break;
                }
                Draw(X, Y);

            InitialDirection = direction;

        }

        public static void CreateCasts(int quantity)
        {
            var random = new Random();
            for(int i = 0; i < quantity; i++)
            {
                int randomX;
                int randomY;
                do
                {
                    randomX = random.Next(1, ConsoleSettings.CONSOLEWIDTH - 1);
                    randomY = random.Next(1, ConsoleSettings.CONSOLEHEIGTH - 1);
                } while (Wall.walls.Any(w => w.wallelems.Any(el => el.X == randomX && el.Y == randomY)) ||
                        Coins.coins.Any(coin => coin.X == randomX && coin.Y == randomY));
                int enumLength = Enum.GetValues(typeof(Direction)).Length;
                int randomIndex = random.Next(0, enumLength);
                var direction = (Direction)randomIndex;
                var monster = new Cast(randomX, randomY, ConsoleColor.DarkBlue, direction);
                casts.Add(monster);
            }
        }

        public static void RunCasts()
        {
            foreach(var monst in casts)
            {
                monst.Move(monst.InitialDirection);
            }
        }
    }
}
