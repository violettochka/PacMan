using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.settings;

namespace PacMan.Models
{
    public class Helper : Pixel
    {
        public Helper(int x, int y, ConsoleColor color) : base(x, y, color)
        {
        }

        private Random Random = new Random();

        private const ConsoleColor HELPERCOLOR = ConsoleColor.Green;

        public static List<Helper> helpers = new List<Helper>();

        public void CreateHelpers(int countHelpers)
        {
            for(int i = 0; i < countHelpers; i++)
            {
                int randomX;
                int randomY;
                Helper helper;
                do
                {
                    randomX = Random.Next(1, ConsoleSettings.CONSOLEWIDTH - 1);
                    randomY = Random.Next(1, ConsoleSettings.CONSOLEHEIGTH - 1);
                    helper = new Helper(randomX, randomY, HELPERCOLOR);
                } 
                while (Wall.walls.Any(w => w.wallelems.Any(el => el.X == randomX && el.Y == randomY)) ||
                       Coins.coins.Any(coin => coin.X == randomX && coin.Y == randomY));
                helpers.Add(helper);
                Draw(helper.X, helper.Y);
            }
        }



    }
}
