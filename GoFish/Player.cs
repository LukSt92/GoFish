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
        public string Status => $"{Name} has {hand.Count()} card{S(hand.Count())} and {books.Count} books";
        public Player(string name) => Name = name;

        public Player(string name, IEnumerable<Card> cards)
        {
            Name = name;
            hand.AddRange(cards);
        }
        public void GetNextHand(Deck stock)
        {
            while (stock.Count() > 0 && hand.Count() < 5)
            {
                hand.Add(stock.Deal(0));
            }
        }
        public IEnumerable<Card> DoYouHaveAny(Values value, Deck deck)
        {
            // TODO
            var cardsToTakeAway = hand.FindAll(x => x.Value == value).OrderBy(x => x.Suit);
            hand.RemoveAll(x => x.Value == value);
            if (hand.Count() == 0)
                GetNextHand(deck);
            return cardsToTakeAway;
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
