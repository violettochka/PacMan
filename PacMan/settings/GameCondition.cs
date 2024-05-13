using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.Models;

namespace PacMan.settings
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

        }

        public static void GameWin(Pacman pacman)
        {
            Console.Clear();

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;
            Console.SetCursorPosition(centerX - ("gameOver, your points: ".Length + pacman.CountCoins.ToString().Length) / 2, centerY);
            Console.Write($"You won, your points: {pacman.CountCoins}");

            Console.WriteLine();

        }

        public static bool GameContinueBorder(Pacman pacman)
        {
            if (pacman.X == ConsoleSettings.CONSOLEWIDTH - 1 ||
               pacman.Y == ConsoleSettings.CONSOLEHEIGTH - 1 ||
               pacman.X == 0 || pacman.Y == 0)
            {
                return false;
            }
            return true;
        }

        public static bool GameContinueWall(Pacman pacman)
        {
            var walls = Wall.walls;
            foreach (var wall in walls)
            {
                if (wall.wallelems.Any(elem => elem.X == pacman.X && elem.Y == pacman.Y))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
