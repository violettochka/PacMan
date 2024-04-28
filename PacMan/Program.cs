using PacMan.Models;

namespace PacMan
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleSettings.ChangeSizeBorder();
            var pacman = new Pacman(1, 1, ConsoleColor.Cyan);
            new Wall(0, 0, ConsoleColor.Red).BuildWall();
            new Coins(0, 0, ConsoleColor.Yellow).CreateandDrawCoins();
            Cast.CreateCasts(5);
            while (GameSettings.GameContinue)
            {
                if (!GameSettings.GameContinueBorder(pacman))
                {
                    GameSettings.GameContinue = false;
                    break;

                }
                if (!GameSettings.GameContinueWall(pacman))
                {
                    GameSettings.GameContinue = false;
                    break;
                }

                if (pacman.BeatByCast(pacman))
                {
                    GameSettings.GameContinue = false;
                    break;
                }
                Cast.RunCasts();
                pacman.InitialDirection = pacman.ReadMovement(pacman.InitialDirection);
                pacman.Move(pacman.InitialDirection);
                Thread.Sleep(100);
            }
        }
    }
}
