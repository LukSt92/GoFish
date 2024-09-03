using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class Player
    {
        public static Random Random = new Random();
        private List<Card> hand = new List<Card>();
        private List<Values> books = new List<Values>();

        public IEnumerable<Card> Hand => hand;
        public IEnumerable<Values> Books => books;
        public readonly string Name;
        public static string S(int s) => s == 1 ? "" : "s";
        public string Status => throw new NotImplementedException(); // TODO
        public Player(string name) => Name = name;

        public Player(string name, IEnumerable<Card> cards)
        {
            Name = name;
            hand.AddRange(cards);
        }
        public void GetNextHand(Deck stock)
        {
            // TODO
        }
        public IEnumerable<Card> DoYouHaveAny(Values value, Deck deck)
        {
            // TODO
            throw new NotImplementedException();
        }
        public void AddCardsAndPullOutBooks(IEnumerable<Card> cards)
        {
            // TODO
        }
        public void DrawCard(Deck stock)
        {
            // TODO
        }
        public Values RandomValueFromHand() => throw new NotImplementedException(); // TODO
        public override string ToString() => Name;
    }
}
