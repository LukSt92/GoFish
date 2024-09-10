using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }
        public Player RandomPlayer(Player currentPlayer) =>
            throw new NotImplementedException();
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
