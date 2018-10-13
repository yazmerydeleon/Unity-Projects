using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        List<Card> cards = new List<Card>();

        //Clubs
        cards.Add(new Card("Clubs", 0));
        cards.Add(new Card("Clubs", 1));
        cards.Add(new Card("Clubs", 2));
        cards.Add(new Card("Clubs", 3));
        cards.Add(new Card("Clubs", 4));
        cards.Add(new Card("Clubs", 5));
        cards.Add(new Card("Clubs", 6));
        cards.Add(new Card("Clubs", 7));
        cards.Add(new Card("Clubs", 8));
        cards.Add(new Card("Clubs", 9));
        cards.Add(new Card("Clubs", 10));
        cards.Add(new Card("Clubs", 11));
        cards.Add(new Card("Clubs", 12));

        //Diamonds
        cards.Add(new Card("Diamonds", 0));
        cards.Add(new Card("Diamonds", 1));
        cards.Add(new Card("Diamonds", 2));
        cards.Add(new Card("Diamonds", 3));
        cards.Add(new Card("Diamonds", 4));
        cards.Add(new Card("Diamonds", 5));
        cards.Add(new Card("Diamonds", 6));
        cards.Add(new Card("Diamondz", 7));
        cards.Add(new Card("Diamonds", 8));
        cards.Add(new Card("Diamonds", 9));
        cards.Add(new Card("Diamonds", 10));
        cards.Add(new Card("Diamonds", 11));
        cards.Add(new Card("Diamonds", 12));

        //Hearts
        cards.Add(new Card("Hearts", 0));
        cards.Add(new Card("Hearts", 1));
        cards.Add(new Card("Hearts", 2));
        cards.Add(new Card("Hearts", 3));
        cards.Add(new Card("Hearts", 4));
        cards.Add(new Card("Hearts", 5));
        cards.Add(new Card("Hearts", 6));
        cards.Add(new Card("Hearts", 7));
        cards.Add(new Card("Hearts", 8));
        cards.Add(new Card("Hearts", 9));
        cards.Add(new Card("Hearts", 10));
        cards.Add(new Card("Hearts", 11));
        cards.Add(new Card("Hearts", 12));

        //Spades
        cards.Add(new Card("Spades", 0));
        cards.Add(new Card("Spades", 1));
        cards.Add(new Card("Spades", 2));
        cards.Add(new Card("Spades", 3));
        cards.Add(new Card("Spades", 4));
        cards.Add(new Card("Spades", 5));
        cards.Add(new Card("Spades", 6));
        cards.Add(new Card("Spades", 7));
        cards.Add(new Card("Spades", 8));
        cards.Add(new Card("Spades", 9));
        cards.Add(new Card("Spades", 10));
        cards.Add(new Card("Spades", 11));
        cards.Add(new Card("Spades", 12));

        foreach (var item in cards)
        {
            print("Card: "+ item.suit +" "+ item.value);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
