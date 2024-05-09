using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PacMan.Models
{
    public class Pixel
    {
        protected const char PIXELCHAR = '█';
        public int X {  get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }

        public Pixel(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public virtual void Draw(int x, int y)
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(x, y);
            Console.Write(PIXELCHAR);
        }

        public virtual void Draw(int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(PIXELCHAR);
        }

        public virtual void Clear(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
    }
}
