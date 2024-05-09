using PacMan.Models;

namespace PacMan
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Налаштування, які нравець може вибрати перед початком гри:
            //1. Колір гравця
            Console.WriteLine("Перед початком гри виберіть бажаний колір гравця(white, blue, green)");
            Console.WriteLine("За замовчуванням колір гравця буде вибрано автоматично");
            var pacmanColor = Console.ReadLine();
            Console.Clear();

            //2. Складність гри
            Console.WriteLine("Tакож необхідно вибрати складність гри." +
                              " Напишіть бажаний рівень гри(цифра від 1 до 5)");
            var input = Console.ReadLine();
            var isValid = int.TryParse(input, out var number);
            if (!isValid)
            {
                Console.WriteLine("Будь-ласка введіть саме число або рівень" +
                                  "складності буде вибрана автоматично");
            }

            //Створення мапи
            ConsoleSettings.ChangeSizeBorder();

            //створення стін
            new Wall(0, 0, ConsoleColor.Red).BuildWall();

            //створення монеток
            new Coins(0, 0, ConsoleColor.Yellow).CreateandDrawCoins();

            //створення енерджайзера
            new Helper(0, 0, ConsoleColor.Green).CreateHelpers(4);

            //створення пакмена
            var pacmanSettings = new EntitiesSettings();
            var pacman = new Pacman(1, 1, pacmanSettings.ColorForPacman(pacmanColor));

            //створення примар
            Cast.CreateCasts(number);

            //
            while (GameCondition.GameContinue)
            {
                if (!GameCondition.GameContinueBorder(pacman))
                {
                    GameCondition.GameContinue = false;
                    break;

                }
                if (!GameCondition.GameContinueWall(pacman))
                {
                    GameCondition.GameContinue = false;
                    break;
                }

                if (pacman.BeatByCast(pacman))
                {
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
