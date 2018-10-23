using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Card
    {
        public string suit;
        public int value;
        public GameObject gameObject;

        public Card(string suit, int value, GameObject gameObject)
        {
            this.suit = suit;
            this.value = value;
            this.gameObject = gameObject;
        }
    }
}
