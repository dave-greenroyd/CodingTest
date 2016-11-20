using System;
using System.Collections.Generic;
using System.Linq;


namespace SkeletonCode.CardGame
{
	public class PackOfCardsCreator : IPackOfCardsCreator
	{
		public IPackOfCards Create()
		{
		    var values =
		        Enumerable.Range(2, 9).Select(x => x.ToString()).Concat(new[] { "Ace", "Jack", "Queen", "King" }).ToList();

            var deck = new List<ICard>();
		    foreach (var suit in Enum.GetValues(typeof(CardSuit)))
		    {
		        deck.AddRange(from value in values select new Card((CardSuit)suit, value));
		    }

			var pack = new PackOfCards(deck);

		    return pack;
		}
	}
}
