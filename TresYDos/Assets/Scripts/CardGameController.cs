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

    private bool HasPlayerWon(List<Card> playerHand)
    {
        return playerHand.Select(card => card.value).Distinct().Count() == 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print("Player1 pressed mouse");

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
                        if (HasPlayerWon(playerOneHand))
                        {
                            print("YOU WON!!!!!");
                        }
                    }
                }
            }
            
        }

    }

    private void PutInPlayerOneHand(List<Card> source, Card card)
    {
        if (card != null)
        {
            card.ShowFace();
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
        foreach (var item in discardPile)
        {
            item.HideFace();
        }
        source.Remove(card);
        card.ShowFace();
        discardPile.Insert(0, card);
        card.gameObject.transform.position = new Vector3(2.88f, 0.1f, 0);
        print("PutInDiscardPile: " + card.value + " of " + card.suit);
    }

    private void AddCardsToList()
    {
        //Clubs
        deck.Add(new Card(Suit.Clubs,  1));
        deck.Add(new Card(Suit.Clubs,  2));
        deck.Add(new Card(Suit.Clubs,  3));
        deck.Add(new Card(Suit.Clubs,  4));
        deck.Add(new Card(Suit.Clubs,  5));
        deck.Add(new Card(Suit.Clubs,  6));
        deck.Add(new Card(Suit.Clubs,  7));
        deck.Add(new Card(Suit.Clubs,  8));
        deck.Add(new Card(Suit.Clubs,  9));
        deck.Add(new Card(Suit.Clubs, 10));
        deck.Add(new Card(Suit.Clubs, 11));
        deck.Add(new Card(Suit.Clubs, 12));
        deck.Add(new Card(Suit.Clubs, 13));

        //Diamonds
        deck.Add(new Card(Suit.Diamonds,  1));
        deck.Add(new Card(Suit.Diamonds,  2));
        deck.Add(new Card(Suit.Diamonds,  3));
        deck.Add(new Card(Suit.Diamonds,  4));
        deck.Add(new Card(Suit.Diamonds,  5));
        deck.Add(new Card(Suit.Diamonds,  6));
        deck.Add(new Card(Suit.Diamonds,  7));
        deck.Add(new Card(Suit.Diamonds,  8));
        deck.Add(new Card(Suit.Diamonds,  9));
        deck.Add(new Card(Suit.Diamonds, 10));
        deck.Add(new Card(Suit.Diamonds, 11));
        deck.Add(new Card(Suit.Diamonds, 12));
        deck.Add(new Card(Suit.Diamonds, 13));

        //Hearts
        deck.Add(new Card(Suit.Hearts,  1));
        deck.Add(new Card(Suit.Hearts,  2));
        deck.Add(new Card(Suit.Hearts,  3));
        deck.Add(new Card(Suit.Hearts,  4));
        deck.Add(new Card(Suit.Hearts,  5));
        deck.Add(new Card(Suit.Hearts,  6));
        deck.Add(new Card(Suit.Hearts,  7));
        deck.Add(new Card(Suit.Hearts,  8));
        deck.Add(new Card(Suit.Hearts,  9));
        deck.Add(new Card(Suit.Hearts, 10));
        deck.Add(new Card(Suit.Hearts, 11));
        deck.Add(new Card(Suit.Hearts, 12));
        deck.Add(new Card(Suit.Hearts, 13));

        //Spades
        deck.Add(new Card(Suit.Spades,  1));
        deck.Add(new Card(Suit.Spades,  2));
        deck.Add(new Card(Suit.Spades,  3));
        deck.Add(new Card(Suit.Spades,  4));
        deck.Add(new Card(Suit.Spades,  5));
        deck.Add(new Card(Suit.Spades,  6));
        deck.Add(new Card(Suit.Spades,  7));
        deck.Add(new Card(Suit.Spades,  8));
        deck.Add(new Card(Suit.Spades,  9));
        deck.Add(new Card(Suit.Spades, 10));
        deck.Add(new Card(Suit.Spades, 11));
        deck.Add(new Card(Suit.Spades, 12));
        deck.Add(new Card(Suit.Spades, 13));
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
