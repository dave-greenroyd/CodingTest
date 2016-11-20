using System.Collections.Generic;

namespace SkeletonCode.CardGame
{
	public interface IPackOfCards : IReadOnlyCollection<ICard>
	{
		void Shuffle ();
		ICard TakeCardFromTopOfPack ();
	}
}
