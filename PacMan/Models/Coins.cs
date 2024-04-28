using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PacMan.Models
{
    public class Coins : Pixel
    {
        public Coins(int x, int y, ConsoleColor color) : base(x, y, color) { }

        private Random Random = new Random();

        private const ConsoleColor COINTCOLOR = ConsoleColor.Yellow;

        public readonly static List<Coins> coins = new List<Coins>();


        public void CreateandDrawCoins()
        {
            for(int i= 0; i < Random.Next(80, 100); i++)
            {
                var randomX = Random.Next(1, ConsoleSettings.CONSOLEWIDTH - 1);
                var randomY = Random.Next(1, ConsoleSettings.CONSOLEHEIGTH - 1);
                if (Wall.walls.Any(w => w.wallelems.Any(el => el.X == randomX && el.Y == randomY)))
                {
                    continue;
                }
                else
                {
                    var coin = new Coins(randomX, randomY, COINTCOLOR);
                    coins.Add(coin);
                    Draw(coin.X, coin.Y);
                }
            }
        }
    }
}
