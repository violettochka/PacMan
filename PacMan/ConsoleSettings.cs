using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Models;
using static System.Console;

namespace PacMan
{
    public static class ConsoleSettings
    {
        public const int CONSOLEWIDTH = 80;
        public const int CONSOLEHEIGTH = 60;

        public static void ChangeSizeBorder()
        {
            Console.CursorVisible = false;
            // size of console
            SetWindowSize(CONSOLEWIDTH, CONSOLEHEIGTH);
            //SetBufferSize(CONSOLEWIDTH, CONSOLEHEIGTH);
            //border of width
            for (int i = 0; i < CONSOLEWIDTH; i++)
            {
                new Pixel(i, 0, ConsoleColor.Red).Draw(i, 0);
                new Pixel(i, CONSOLEHEIGTH - 1, ConsoleColor.Red).Draw(i, CONSOLEHEIGTH - 1);
            }

            //border of heigth
            for(int i = 0; i < CONSOLEHEIGTH - 1; i++)
            {
                new Pixel(0, i, ConsoleColor.Red).Draw(0, i);
                new Pixel(CONSOLEWIDTH - 1, i, ConsoleColor.Red).Draw(CONSOLEWIDTH - 1, i);
            };
        }
    }
}
