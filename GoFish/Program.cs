using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> namesOfOpponents = new List<string>();
            bool isSettingsGood = false;
            Console.Write("Enter your name: ");
            string humanPlayerName = Console.ReadLine();
            while (isSettingsGood == false)
            {
                Console.Write("Enter the number of computer opponents: ");
                string numberOfOpponents = Console.ReadLine();
                if (Int32.TryParse(numberOfOpponents, out int number))
                {
                    if (number > 0 && number < 6)
                    {
                        for (int i = 0; number > i; i++)
                        {
                            namesOfOpponents.Add($"Computer #{i + 1}");
                            isSettingsGood = true;
                        }
                    }
                    else
                        Console.WriteLine("The number is wrong, please choose beetwen 1 to 5 opponents.");
                }
                else
                    Console.WriteLine("NUMBERS ONLY!");
            }
            GameController gameController = new GameController(humanPlayerName, namesOfOpponents);
            Console.WriteLine(gameController.Status);
        }
    }
}
