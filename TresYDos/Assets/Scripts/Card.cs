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
        public GameObject text;

        public Card(Suit suit, int value)
        {
            this.suit = suit;
            this.value = value;

            string objectName;
            switch (suit)
            {
                case Suit.Clubs:
                    objectName = "C";
                    break;
                case Suit.Diamonds:
                    objectName = "D";
                    break;
                case Suit.Hearts:
                    objectName = "H";
                    break;
                case Suit.Spades:
                    objectName = "S";
                    break;
                default:
                    objectName = "Error";
                    break;
            }

            objectName += "_" + value;

            this.gameObject = GameObject.Find(objectName);
            this.text = GameObject.Find(objectName + "_Text");
            this.text.SetActive(false);
        }

        internal void ShowFace()
        {
            text.SetActive(true);
        }

        internal void HideFace()
        {
            text.SetActive(false);
        }
    }
}
