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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Player1 pressed mouse");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    var clickedObject = hit.transform.gameObject;
                    print("Clicked: " + clickedObject.name);
                    if (clickedObject.name == "DeckHolder")
                    {
                        PutInPlayerOneHand(deck, deck.FirstOrDefault());
                       // hit.transform.gameObject.layer = 2;
                    }

                    if (clickedObject.name == "PileHolder")
                    {
                        PutInPlayerOneHand(discardPile, discardPile.FirstOrDefault());
                       // hit.transform.gameObject.layer = 2;
                    }

                    var clickedCardFromPlayerOneHand = playerOneHand.FirstOrDefault(o => o.gameObject == clickedObject);

                    if (clickedCardFromPlayerOneHand != null)
                    {
                        PutInDiscardPile(playerOneHand, clickedCardFromPlayerOneHand);
                    }
                }
            }
        }
    }

    private void PutInPlayerOneHand(List<Card> source, Card card)
    {
        if (card != null)
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
        discardPile.Insert(0, card);
        card.gameObject.transform.position = new Vector3(2.88f, 0.1f, 0);
        print("PutInDiscardPile: " + card.value + " of " + card.suit);
    }

    private void AddCardsToList()
    {
        //Clubs
        deck.Add(new Card(Suit.Clubs,  1, GameObject.Find("C_1")));
        deck.Add(new Card(Suit.Clubs,  2, GameObject.Find("C_2")));
        deck.Add(new Card(Suit.Clubs,  3, GameObject.Find("C_3")));
        deck.Add(new Card(Suit.Clubs,  4, GameObject.Find("C_4")));
        deck.Add(new Card(Suit.Clubs,  5, GameObject.Find("C_5")));
        deck.Add(new Card(Suit.Clubs,  6, GameObject.Find("C_6")));
        deck.Add(new Card(Suit.Clubs,  7, GameObject.Find("C_7")));
        deck.Add(new Card(Suit.Clubs,  8, GameObject.Find("C_8")));
        deck.Add(new Card(Suit.Clubs,  9, GameObject.Find("C_9")));
        deck.Add(new Card(Suit.Clubs, 10, GameObject.Find("C_10")));
        deck.Add(new Card(Suit.Clubs, 11, GameObject.Find("C_11")));
        deck.Add(new Card(Suit.Clubs, 12, GameObject.Find("C_12")));
        deck.Add(new Card(Suit.Clubs, 13, GameObject.Find("C_13")));

        //Diamonds
        deck.Add(new Card(Suit.Diamonds,  1, GameObject.Find("D_1")));
        deck.Add(new Card(Suit.Diamonds,  2, GameObject.Find("D_2")));
        deck.Add(new Card(Suit.Diamonds,  3, GameObject.Find("D_3")));
        deck.Add(new Card(Suit.Diamonds,  4, GameObject.Find("D_4")));
        deck.Add(new Card(Suit.Diamonds,  5, GameObject.Find("D_5")));
        deck.Add(new Card(Suit.Diamonds,  6, GameObject.Find("D_6")));
        deck.Add(new Card(Suit.Diamonds,  7, GameObject.Find("D_7")));
        deck.Add(new Card(Suit.Diamonds,  8, GameObject.Find("D_8")));
        deck.Add(new Card(Suit.Diamonds,  9, GameObject.Find("D_9")));
        deck.Add(new Card(Suit.Diamonds, 10, GameObject.Find("D_10")));
        deck.Add(new Card(Suit.Diamonds, 11, GameObject.Find("D_11")));
        deck.Add(new Card(Suit.Diamonds, 12, GameObject.Find("D_12")));
        deck.Add(new Card(Suit.Diamonds, 13, GameObject.Find("D_13")));

        //Hearts
        deck.Add(new Card(Suit.Hearts,  1, GameObject.Find("H_1")));
        deck.Add(new Card(Suit.Hearts,  2, GameObject.Find("H_2")));
        deck.Add(new Card(Suit.Hearts,  3, GameObject.Find("H_3")));
        deck.Add(new Card(Suit.Hearts,  4, GameObject.Find("H_4")));
        deck.Add(new Card(Suit.Hearts,  5, GameObject.Find("H_5")));
        deck.Add(new Card(Suit.Hearts,  6, GameObject.Find("H_6")));
        deck.Add(new Card(Suit.Hearts,  7, GameObject.Find("H_7")));
        deck.Add(new Card(Suit.Hearts,  8, GameObject.Find("H_8")));
        deck.Add(new Card(Suit.Hearts,  9, GameObject.Find("H_9")));
        deck.Add(new Card(Suit.Hearts, 10, GameObject.Find("H_10")));
        deck.Add(new Card(Suit.Hearts, 11, GameObject.Find("H_11")));
        deck.Add(new Card(Suit.Hearts, 12, GameObject.Find("H_12")));
        deck.Add(new Card(Suit.Hearts, 13, GameObject.Find("H_13")));

        //Spades
        deck.Add(new Card(Suit.Spades,  1, GameObject.Find("S_1")));
        deck.Add(new Card(Suit.Spades,  2, GameObject.Find("S_2")));
        deck.Add(new Card(Suit.Spades,  3, GameObject.Find("S_3")));
        deck.Add(new Card(Suit.Spades,  4, GameObject.Find("S_4")));
        deck.Add(new Card(Suit.Spades,  5, GameObject.Find("S_5")));
        deck.Add(new Card(Suit.Spades,  6, GameObject.Find("S_6")));
        deck.Add(new Card(Suit.Spades,  7, GameObject.Find("S_7")));
        deck.Add(new Card(Suit.Spades,  8, GameObject.Find("S_8")));
        deck.Add(new Card(Suit.Spades,  9, GameObject.Find("S_9")));
        deck.Add(new Card(Suit.Spades, 10, GameObject.Find("S_10")));
        deck.Add(new Card(Suit.Spades, 11, GameObject.Find("S_11")));
        deck.Add(new Card(Suit.Spades, 12, GameObject.Find("S_12")));
        deck.Add(new Card(Suit.Spades, 13, GameObject.Find("S_13")));
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
