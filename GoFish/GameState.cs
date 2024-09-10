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
        public string PlayRound(Player player, Player playerToAsk, Values valueTOAskFor, Deck stock)
        {
            throw new NotImplementedException();
        }
        public string CheckForWinner()
        {
            throw new NotImplementedException();
        }
    }
}
