using System;
using System.Collections.Generic;

public class CommonArea
{
    private int NumPlayers;
    private List<Stack<Card>> Piles = null; 

    public CommonArea(int numPlayers)
    {
        this.NumPlayers = numPlayers;
        this.Piles = new List<Stack<Card>>();
    }

    // This method will have to be locked when multi-threading is implemented
    public bool PlayCard(Card card)
    {
        if (card.Value == 1)
        {
            Piles.Add(new Stack<Card>());
            int stackNum = Piles.Count;
            Piles[stackNum].Push(card);
            return true;
        }
        else
        {   
            // Search all piles in the common area for a card to play on
            for (int i = 0; i < this.Piles.Count; i++)
            {
                string topCard = this.Piles[i].Peek().ToString();
                string playOnCard = card.PlayOnCommon.ToString();

                if (topCard == playOnCard)
                {
                    this.Piles[i].Push(card);
                    return true;
                }
            }
        }

        return false;
    }

    public override string ToString()
    {
        string output = "";
        List<string> pileCards = new List<string>();
        foreach (Stack<Card> pile in this.Piles)
        {
            pileCards.Add(pile.Peek().ToString());
        }
        return string.Join(" | ", pileCards);
    }
}