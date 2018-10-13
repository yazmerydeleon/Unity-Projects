using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Card
    {
        public string suit;
        public int value;
        
        public Card(string newSuit, int newValue)
        {
            suit = newSuit;
            value = newValue;
        }
    }
}
