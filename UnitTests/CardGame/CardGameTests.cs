using NUnit.Framework;
using SkeletonCode.CardGame;

namespace UnitTests.CardGame
{
	[TestFixture]
	public class CardGameTests
	{
		[Test]
		public void ThePackOfCardsShouldContain52CardsWhenCreated ()
		{
			IPackOfCardsCreator packOfCardsCreator = new PackOfCardsCreator();
			IPackOfCards packOfCards = packOfCardsCreator.Create();
			const int expectedNumberOfCards = 52;
			int numberOfCards = packOfCards.Count;

			Assert.AreEqual(expectedNumberOfCards, numberOfCards);
		}

		[Test]
		public void TheCardsShouldAllBeUniqueAfterTheShuffle ()
		{
			IPackOfCardsCreator packOfCardsCreator = new PackOfCardsCreator();
			IPackOfCards packOfCards = packOfCardsCreator.Create();

			packOfCards.Shuffle();

			CollectionAssert.AllItemsAreUnique(packOfCards);
		}

		[Test]
		public void ThePackOfCardsShouldContainTheSameNumberOfCardsWhenShuffled()
		{
			IPackOfCardsCreator packOfCardsCreator = new PackOfCardsCreator();
			IPackOfCards packOfCards = packOfCardsCreator.Create();
			int expectedCount = packOfCards.Count;

			packOfCards.Shuffle();

			int resultCount = packOfCards.Count;

			Assert.AreEqual(expectedCount, resultCount);
		}

		[Test]
		public void TheCountOfThePackShouldDecreaseByOneAfterACardIsTakenFromTheTop()
		{
			IPackOfCardsCreator packOfCardsCreator = new PackOfCardsCreator();
			IPackOfCards packOfCards = packOfCardsCreator.Create();
			int countBeforeTheCardIsRemoved = packOfCards.Count;
			int expectedCountAfterCut = countBeforeTheCardIsRemoved - 1;

			ICard card = packOfCards.TakeCardFromTopOfPack();

			int countResult = packOfCards.Count;

			Assert.AreEqual(expectedCountAfterCut, countResult);
		}

		[Test]
		public void TheCardShouldNoLongerBeInThePackAfterACardIsRemoved()
		{
			IPackOfCardsCreator packOfCardsCreator = new PackOfCardsCreator();
			IPackOfCards packOfCards = packOfCardsCreator.Create();
			
			ICard cardRemoved = packOfCards.TakeCardFromTopOfPack();

			CollectionAssert.DoesNotContain(packOfCards, cardRemoved);
		}
	}
}
