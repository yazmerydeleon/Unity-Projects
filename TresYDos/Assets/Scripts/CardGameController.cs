using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGameController : MonoBehaviour {

    List<Card> deck = new List<Card>();

    List<Card> playerOneHand = new List<Card>();
    List<Card> playerTwoHand = new List<Card>();
    List<Card> discardPile = new List<Card>();

    // Use this for initialization
    void Start ()
    {
        AddCardsToList();

        Shuffle(deck);

        for (int i = 0; i < 10; i++)
        {
            var cardForPlayers = deck.First();
            if (i % 2 == 0)
            {
                PutInPlayerOneHand(deck, cardForPlayers);
            }
            else
            {
                PutInPlayerTwoHand(deck, cardForPlayers);
            }
        }

        var cardForDiscard = deck.First();
        PutInDiscardPile(deck, cardForDiscard);
    }

    private void PutInPlayerOneHand(List<Card> source, Card card)
    {
        source.Remove(card);
        playerOneHand.Add(card);
        print("PutInPlayerOneHand: " + card.value + " of " + card.suit);

        for (int i = 0; i < playerOneHand.Count; i++)
        {
            float x = -6.3f + (i * 2.5f);
            playerOneHand[i].gameObject.transform.position = new Vector3(x, 0.1f, -7);
        }
    }

    private void PutInPlayerTwoHand(List<Card> source, Card card)
    {
        source.Remove(card);
        playerTwoHand.Add(card);
        print("PutInPlayerTwoHand: " + card.value + " of " + card.suit);

        for (int i = 0; i < playerTwoHand.Count; i++)
        {
            float x = -6.3f + (i * 2.5f);
            playerTwoHand[i].gameObject.transform.position = new Vector3(x, 0.1f, 7);
        }
    }

    private void PutInDiscardPile(List<Card> source, Card card)
    {
        source.Remove(card);
        discardPile.Add(card);
        card.gameObject.transform.position = new Vector3(2.88f, 0.1f, 0);
        print("PutInDiscardPile: " + card.value + " of " + card.suit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddCardsToList()
    {
        //Clubs
        deck.Add(new Card("Clubs",  1, GameObject.Find("C_1")));
        deck.Add(new Card("Clubs",  2, GameObject.Find("C_2")));
        deck.Add(new Card("Clubs",  3, GameObject.Find("C_3")));
        deck.Add(new Card("Clubs",  4, GameObject.Find("C_4")));
        deck.Add(new Card("Clubs",  5, GameObject.Find("C_5")));
        deck.Add(new Card("Clubs",  6, GameObject.Find("C_6")));
        deck.Add(new Card("Clubs",  7, GameObject.Find("C_7")));
        deck.Add(new Card("Clubs",  8, GameObject.Find("C_8")));
        deck.Add(new Card("Clubs",  9, GameObject.Find("C_9")));
        deck.Add(new Card("Clubs", 10, GameObject.Find("C_10")));
        deck.Add(new Card("Clubs", 11, GameObject.Find("C_11")));
        deck.Add(new Card("Clubs", 12, GameObject.Find("C_12")));
        deck.Add(new Card("Clubs", 13, GameObject.Find("C_13")));

        //Diamonds
        deck.Add(new Card("Diamonds",  1, GameObject.Find("D_1")));
        deck.Add(new Card("Diamonds",  2, GameObject.Find("D_2")));
        deck.Add(new Card("Diamonds",  3, GameObject.Find("D_3")));
        deck.Add(new Card("Diamonds",  4, GameObject.Find("D_4")));
        deck.Add(new Card("Diamonds",  5, GameObject.Find("D_5")));
        deck.Add(new Card("Diamonds",  6, GameObject.Find("D_6")));
        deck.Add(new Card("Diamondz",  7, GameObject.Find("D_7")));
        deck.Add(new Card("Diamonds",  8, GameObject.Find("D_8")));
        deck.Add(new Card("Diamonds",  9, GameObject.Find("D_9")));
        deck.Add(new Card("Diamonds", 10, GameObject.Find("D_10")));
        deck.Add(new Card("Diamonds", 11, GameObject.Find("D_11")));
        deck.Add(new Card("Diamonds", 12, GameObject.Find("D_12")));
        deck.Add(new Card("Diamonds", 13, GameObject.Find("D_13")));

        //Hearts
        deck.Add(new Card("Hearts",  1, GameObject.Find("H_1")));
        deck.Add(new Card("Hearts",  2, GameObject.Find("H_2")));
        deck.Add(new Card("Hearts",  3, GameObject.Find("H_3")));
        deck.Add(new Card("Hearts",  4, GameObject.Find("H_4")));
        deck.Add(new Card("Hearts",  5, GameObject.Find("H_5")));
        deck.Add(new Card("Hearts",  6, GameObject.Find("H_6")));
        deck.Add(new Card("Hearts",  7, GameObject.Find("H_7")));
        deck.Add(new Card("Hearts",  8, GameObject.Find("H_8")));
        deck.Add(new Card("Hearts",  9, GameObject.Find("H_9")));
        deck.Add(new Card("Hearts", 10, GameObject.Find("H_10")));
        deck.Add(new Card("Hearts", 11, GameObject.Find("H_11")));
        deck.Add(new Card("Hearts", 12, GameObject.Find("H_12")));
        deck.Add(new Card("Hearts", 13, GameObject.Find("H_13")));

        //Spades
        deck.Add(new Card("Spades",  1, GameObject.Find("S_1")));
        deck.Add(new Card("Spades",  2, GameObject.Find("S_2")));
        deck.Add(new Card("Spades",  3, GameObject.Find("S_3")));
        deck.Add(new Card("Spades",  4, GameObject.Find("S_4")));
        deck.Add(new Card("Spades",  5, GameObject.Find("S_5")));
        deck.Add(new Card("Spades",  6, GameObject.Find("S_6")));
        deck.Add(new Card("Spades",  7, GameObject.Find("S_7")));
        deck.Add(new Card("Spades",  8, GameObject.Find("S_8")));
        deck.Add(new Card("Spades",  9, GameObject.Find("S_9")));
        deck.Add(new Card("Spades", 10, GameObject.Find("S_10")));
        deck.Add(new Card("Spades", 11, GameObject.Find("S_11")));
        deck.Add(new Card("Spades", 12, GameObject.Find("S_12")));
        deck.Add(new Card("Spades", 13, GameObject.Find("S_13")));
    }

    private static System.Random rng = new System.Random();

    private static void Shuffle<T>(IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
