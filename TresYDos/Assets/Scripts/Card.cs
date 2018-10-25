using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Card
    {
        public Suit suit;
        public int value;
        public GameObject gameObject;

        public Card(Suit suit, int value, GameObject gameObject)
        {
            this.suit = suit;
            this.value = value;
            this.gameObject = gameObject;
        }
    }
}
