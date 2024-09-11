using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class GameState
    {
        public readonly IEnumerable<Player> Players;
        public readonly IEnumerable<Player> Opponents;
        public readonly Player HumanPlayer;
        public bool GameOver { get; private set; } = false;
        public readonly Deck Stock;
        public GameState(string humanPlayerName, IEnumerable<string> opponentNames, Deck stock)
        {
            this.Stock = stock;
            HumanPlayer = new Player(humanPlayerName);
            HumanPlayer.GetNextHand(Stock);
            var opponents = new List<Player>();
            foreach (var name in opponentNames)
            {
                var player = new Player(name);
                player.GetNextHand(Stock);
                opponents.Add(player);
            }
            Opponents = opponents;
            Players = new List<Player>() { HumanPlayer}.Concat(Opponents);
        }
        public Player RandomPlayer(Player currentPlayer) => Players.Where(x => x != currentPlayer).Skip(Player.Random.Next(Players.Count() - 1)).First();
        public string PlayRound(Player player, Player playerToAsk, Values valueToAskFor, Deck stock)
        {
            var valuePlural = (valueToAskFor == Values.Six) ? "Sixes" : $"{valueToAskFor}s";
            var message = $"{player.Name} asked {playerToAsk.Name}"
                        + $" for {valuePlural}{Environment.NewLine}";
            var cards = playerToAsk.DoYouHaveAny(valueToAskFor, stock);
            if (cards.Count() > 0)
            {
                player.AddCardsAndPullOutBooks(cards);
                message += $"{playerToAsk.Name} has {cards.Count()}"
                            + $" {valueToAskFor} card{Player.S(cards.Count())}";
            }
            else if (stock.Count == 0)
                message += $"The stock is out of cards";
            else
            {
                player.DrawCard(stock);
                message += $"{player.Name} drew a card{Environment.NewLine}";
            }
            if (player.Hand.Count() == 0)
            {
                player.GetNextHand(stock);
                message += $"{Environment.NewLine}{player.Name} ran out of cards,"
                        + $" drew {player.Hand.Count()} from the stock";
            }
            return message;
        }
        public string CheckForWinner()
        {
            var playerCards = Players.Select(x => x.Hand.Count()).Sum();
            if (playerCards > 0) return "";
            GameOver = true;
            var winningBookCount = Players.Select(player => player.Books.Count()).Max();
            var winners = Players.Where(player => player.Books.Count() == winningBookCount);
            if (winners.Count() == 1) return $"The winner is {winners.First().Name}";
            return $"The winners are {string.Join(" and ", winners)}";
        }
    }
}
