using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public List<Stack<Card>> WorkPiles = null;  // 4 piles of cards to play on
    public Stack<Card> NertsPile = null;        // Nerts cards
    public Stack<Card> Stock = null;            // Stock of cards to play from
    public Stack<Card> Waste = null;            // Discard pile
    public string Name = null;
    public int Score = 0;

    public Player(string name) 
    {
        this.ResetAll();
        this.Name = name;
    }

    /********************************/
    /* Interactions with the player */
    /********************************/
    public void ResetAll()
    {
        this.CreateNewDeck();
        this.ShuffleDeck();
        this.CreateNertsPile();
        this.CreateWorkPiles();
        this.Waste = new Stack<Card>();
    }

    public void CreateNewDeck()
    {
        this.Stock = new Stack<Card>();
        for (int i = 0; i < 4; i++)
        {
            for (int k = 1; k <= 13; k++)
            {
                Suit tempSuit;
                if (i == 0)
                    tempSuit = Suit.Club;
                else if (i == 1)
                    tempSuit = Suit.Spade;
                else if (i == 2)
                    tempSuit = Suit.Diamond;
                else
                    tempSuit = Suit.Heart;
                
                this.Stock.Push(new Card(tempSuit, k, this.Name));
            }
        }
    }

    public void ShuffleDeck()
    {
        Random rnd = new Random();
        this.Stock = new Stack<Card>(this.Stock.OrderBy(x => rnd.Next()));
    }

    // Currently this plays with the 13th card on top, instead of the first card on top
    public void CreateNertsPile()
    {
        this.NertsPile = new Stack<Card>();
        for (int i = 0; i < 13; i++)
        {
            this.NertsPile.Push(this.Stock.Pop());
        }
    }

    public void CreateWorkPiles()
    {
        this.WorkPiles = new List<Stack<Card>>();
        for (int i = 0; i < 4; i++)
        {
            this.WorkPiles.Add(new Stack<Card>());
            this.WorkPiles[i].Push(this.Stock.Pop());
        }
    }
    
    /**********************************************/
    /* Getting different cards from various piles */
    /**********************************************/
    public Card GetTopNertsCard()
    {
        return this.NertsPile.Peek();
    }

    public Card GetTopStockCard()
    {
        return this.Stock.Peek();
    }

    public Card GetTopWasteCard()
    {
        return this.Waste.Peek();
    }

    public void FlipThree()
    {
        int i = 0;
        while (this.Stock.Count > 0 && i < 3)
        {
            this.Waste.Push(this.Stock.Pop());
            i++;
        }
    }

    public override string ToString()
    {
        string outputStr = $"{this.Name}:\n";
        foreach (Stack<Card> pile in this.WorkPiles)
        {
            outputStr += $"[{pile.Peek().ToString()}]";
        }
        if (this.NertsPile.Count > 0)
            outputStr += $" | [{this.NertsPile.Peek().ToString()}]\n";

        if (this.Waste.Count > 0)
            outputStr += $"[{this.Waste.Peek().ToString()}]";

        return outputStr;
    }
}