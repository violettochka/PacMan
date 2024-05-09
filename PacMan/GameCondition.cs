using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Models;

namespace PacMan
{
    public static class GameCondition
    {
        public static bool GameContinue = true;

        public static void Gameover(Pacman pacman)
        {
            Console.Clear();

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;
            Console.SetCursorPosition(centerX - ("gameOver, your points: ".Length + pacman.CountCoins.ToString().Length) / 2, centerY);
            Console.Write($"gameOver, your points: {pacman.CountCoins}");

            Console.WriteLine();

            Console.SetCursorPosition(centerX - ("For quitting write 'quit'".Length) / 2, Console.CursorTop + 1);
            Console.WriteLine("For quitting write 'quit'");
            string newGame = Console.ReadLine();
            if(newGame == "again")
            {
                GameContinue = true;
            }
        }
        public static bool GameContinueBorder(Pacman pacman)
        {
            if (pacman.X == ConsoleSettings.CONSOLEWIDTH - 1 ||
               pacman.Y == ConsoleSettings.CONSOLEHEIGTH - 1 ||
               pacman.X == 0 || pacman.Y == 0)
            {
                Gameover(pacman);
                return false;
            }
            return true;
        }

        public static bool GameContinueWall(Pacman pacman)
        {
            var walls = Wall.walls;
            foreach ( var wall in walls )
            {
                if(wall.wallelems.Any(elem => elem.X == pacman.X &&  elem.Y == pacman.Y))
                {
                    Gameover(pacman);
                    return false;
                }
            }

            return true;
        }
    }
}
