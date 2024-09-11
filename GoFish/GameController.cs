using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class GameController
    {
        public static Random Random = new Random();

        private GameState gameState;
        public bool GameOver { get { return gameState.GameOver; } }
        public Player HumanPlayer { get { return gameState.HumanPlayer; } }
        public IEnumerable<Player> Opponents { get { return gameState.Opponents; } }
        public string Status { get; private set; }
        public GameController(string humanPlayerName, IEnumerable<string> computerPlayerNames)
        {
            gameState = new GameState(humanPlayerName, computerPlayerNames, new Deck().Shuffle());
            Status = $"Starting a new game with players {HumanPlayer.Name}";
            foreach (var player in Opponents)
                Status += $", {player.Name}";
        }
        public void NextRound(Player playerToAsk, Values valueToAskFor)
        {

            Status = gameState.PlayRound(HumanPlayer, playerToAsk, valueToAskFor, gameState.Stock) + Environment.NewLine;
            ComputerPlayersPlayNextRound();
            Status += string.Join(Environment.NewLine,
                                  gameState.Players.Select(player => player.Status));
            Status += $"{Environment.NewLine}The stock has {gameState.Stock.Count()} cards";
            Status += Environment.NewLine + gameState.CheckForWinner();
        }
        private void ComputerPlayersPlayNextRound()
        {
            IEnumerable<Player> playersWithCards;
            do
            {
                playersWithCards = gameState.Opponents.Where(player => player.Hand.Count() > 0);
                foreach (var player in playersWithCards)
                    Status += gameState.PlayRound(player, gameState.RandomPlayer(player), player.RandomValueFromHand(), gameState.Stock);

            } while ((HumanPlayer.Hand.Count() == 0) && (playersWithCards.Count() > 0));
        }
        public void NewGame()
        {
            var computerPlayerNames = Opponents.Select(player => player.Name).ToList();
            gameState = new GameState(HumanPlayer.Name, computerPlayerNames, new Deck().Shuffle());
            Status = "Starting a new game";
        }
    }
}
