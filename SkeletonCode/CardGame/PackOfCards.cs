using System;
using System.Collections.Generic;
using System.Linq;

namespace SkeletonCode.CardGame
{
    public class PackOfCards : IPackOfCards
    {
        private readonly List<ICard> _pack;

        public PackOfCards(List<ICard> pack)
        {
            _pack = pack;
        }

        public void Shuffle()
        {
            if (!_pack.Any())
            {
                // Note: I would normally add a bespoke exception to handle failures like this so that the 
                // error can be handle correctly. I would also extend the tests to handle the exception.
                throw new Exception("No cards found in deck");
            }

            var random = new Random();
            for (var i = _pack.Count - 1; i > 0; i--)
            {
                var temp = _pack[i];
                var index = random.Next(0, i + 1);
                _pack[i] = _pack[index];
                _pack[index] = temp;
            }
        }

        public ICard TakeCardFromTopOfPack()
        {
            if (!_pack.Any())
            {
                // Note: I would normally add a bespoke exception to handle failures like this so that the 
                // error can be handle correctly by the caller. I would also extend the tests to handle the exception.
                throw new Exception("No cards found in deck");
            }

            var card = _pack.First();
            _pack.RemoveAt(0);
            return (card);
        }

        public int Count
        {
            get
            {
                return _pack.Count;
            }
        }

        public IEnumerator<ICard> GetEnumerator()
        {
            return _pack.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _pack.GetEnumerator();
        }
    }
}
