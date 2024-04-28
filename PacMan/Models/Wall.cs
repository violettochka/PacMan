using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.Models
{
    public class Wall : Pixel
    {
        public static readonly List<Wall> walls = new List<Wall>();
        public List<Pixel> wallelems;
        public int[] Head {  get; private set; }
        private readonly ConsoleColor wallColor;
        private int Size;
        private Random random = new Random();
        public Wall(int x, int y, ConsoleColor color, int size = 7) : base(x, y, color)
        {
            Head = [x, y];
            X = Head[0];
            Y = Head[1];
            Size = size;
            wallelems = new List<Pixel>(size);
            wallColor = color;
        }

        public void BuildWall()
        {
            for(int i = 0; i < random.Next(75, 90); i++)
            {
                var direction = random.Next(1, 3);

                var randomX = random.Next(2, (ConsoleSettings.CONSOLEWIDTH - 1) / 2) * 2;
                var randomY = random.Next(2, (ConsoleSettings.CONSOLEHEIGTH - 1) / 2) * 2;
                var wall = new Wall(randomX, randomY, wallColor);

                Head = [randomX, randomY];

                wall.wallelems.Add(new Pixel(Head[0], Head[1], wallColor));
                for (int j = 1; j < Size; j++)
                {
                    var current = wall.wallelems.LastOrDefault();
                    if (walls.Any(w => w.wallelems.Any(el => el.X == current.X && el.Y == current.Y)))
                    {
                        break;
                    }
                    else
                    {
                        if (direction == 1)
                        {
                            wall.wallelems.Add(new Pixel(current.X, current.Y + 1, wallColor));
                        }
                        else
                        {
                            wall.wallelems.Add(new Pixel(current.X + 1, current.Y, wallColor));
                        }
                    }
                  
                }
                walls.Add(wall);
                DrawWall(wall);
            }

        }

        public  void DrawWall(Wall wall)
        {
            var elems = wall.wallelems;
            foreach(var elem in elems)
            {
                elem.Draw(elem.X, elem.Y);
                if (elem.X == ConsoleSettings.CONSOLEWIDTH - 1 ||
                    elem.Y == ConsoleSettings.CONSOLEHEIGTH - 1 ||
                    elem.X == 0 || elem.Y == 0)
                {
                    break;
                }
            }
        }
    }
}
