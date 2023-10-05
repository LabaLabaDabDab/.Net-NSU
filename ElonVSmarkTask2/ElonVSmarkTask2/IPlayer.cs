using CardDeck;
using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonVSmarkTask2
{
    public interface IPlayer
    {
        public string Name { get; }
        int MakeMove(Card[] cards);
    }
}
