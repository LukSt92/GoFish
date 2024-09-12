using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
                if (int.TryParse(numberOfOpponents, out int number))
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
        static GameController gameController;
        static Values PromptForAValue()
        {
            var handValues = gameController.HumanPlayer.Hand.Select(card => card.Value).ToList();
            Console.Write("What card value do you want to ask for? ");            
            while (true)
            {
                if (Enum.TryParse(Console.ReadLine(), out Values value) && handValues.Contains(value))
                    return value;
                else
                    Console.WriteLine("Please enter a value in your hand");
            }
        }
        static Player PromptForAnOpponent()
        {
            var opponentList = gameController.Opponents.ToList();
            for (int i = 1; i > opponentList.Count(); i++)
                Console.WriteLine($"{i}. {opponentList[i - 1]}");
            Console.Write("Who do you want to ask for a card? ");
            while (true)
                if (int.TryParse(Console.ReadLine(), out var value) && value >= 1 && value <= opponentList.Count())
                    return opponentList[value - 1];
                else
                    Console.Write($"Please enter a number from 1 to {opponentList.Count()}: ");
        }
    }
}
