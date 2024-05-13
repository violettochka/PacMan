using PacMan.Models;
using PacMan.settings;

namespace PacMan
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Налаштування, які нравець може вибрати перед початком гри:
            //1. Колір гравця
            Console.WriteLine("Before starting the game, select the desired color of the player(white, blue, green)");
            Console.WriteLine("By default, the player's color will be selected automatically");
            var pacmanColor = Console.ReadLine();
            Console.Clear();

            //2. Складність гри
            Console.WriteLine("It is also necessary to choose the difficulty of the game." +
                              " Write the desired level of the game (a number from 3 to 5)");
            var input = Console.ReadLine();
            var isValid = int.TryParse(input, out var number);
            if (!isValid)
            {
                Console.WriteLine("Please enter the exact number or level" +
                                  "difficulty will be selected automatically");
            }

            //Створення мапи
            ConsoleSettings.ChangeSizeBorder();

            //створення стін
            new Wall(0, 0, ConsoleColor.Red).BuildWall();

            //створення монеток
            new Coins(0, 0, ConsoleColor.Yellow).CreateandDrawCoins();

            //створення енерджайзера
            new Helper(0, 0, ConsoleColor.Green).CreateHelpers(2);

            //створення пакмена
            var pacmanSettings = new EntitiesSettings();
            var pacman = new Pacman(1, 1, pacmanSettings.ColorForPacman(pacmanColor));

            //створення примар
            Cast.CreateCasts(number);

            //основний цикл гри
            while (GameCondition.GameContinue)
            {
                if (!GameCondition.GameContinueBorder(pacman))
                {
                    GameCondition.Gameover(pacman);
                    GameCondition.GameContinue = false;
                    break;

                }
                if (!GameCondition.GameContinueWall(pacman))
                {
                    GameCondition.Gameover(pacman);
                    GameCondition.GameContinue = false;
                    break;
                }

                if (pacman.BeatByCast(pacman))
                {
                    GameCondition.Gameover(pacman);
                    GameCondition.GameContinue = false;
                    break;
                }

                if(Coins.CountCoins == pacman.CountCoins)
                {
                    GameCondition.GameWin(pacman);
                    GameCondition.GameContinue = false;
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
