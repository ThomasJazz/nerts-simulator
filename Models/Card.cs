using System;
using System.Collections.Generic;
using System.Globalization;
public class Card
{
    public Suit Suit;
    public Color Color;
    public int Value;
    public Card PlayOnCommon = null;
    public List<Card> PlayOnWork = null;
    public string Owner = null;
    public Card(Suit suit, int value, string owner)
    {
        // Set/initialize card properties
        this.Suit = suit;
        this.Value = value;
        this.Owner = owner;
        this.PlayOnWork = new List<Card>();

        // Set card color based on suit
        if (this.Suit == Suit.Club || this.Suit == Suit.Spade)
            this.Color = Color.Black;
        else if (this.Suit == Suit.Heart || this.Suit == Suit.Diamond)
            this.Color = Color.Red;

        // Set the card that can be played on in the common area
        if (this.Value > 1 && this.Value < 16)
        {
            this.PlayOnCommon = new Card(suit, this.Value - 1);
        }
        else if (this.Value == 1)   // Aces don't need a card to play on
        {
            this.PlayOnCommon = null;
        }
        else
        {
            throw new Exception($"Error. Invalid card value given: {this.Value.ToString()}");
        }

        // Set the cards that can be played on when in the work piles
        if (this.Color == Color.Black)
        {
            Card card1 = new Card(Suit.Diamond, this.Value + 1);
            Card card2 = new Card(Suit.Heart, this.Value + 1);
            this.PlayOnWork.Add(card1);
            this.PlayOnWork.Add(card2);
        }
        else
        {
            Card card1 = new Card(Suit.Club, this.Value + 1);
            Card card2 = new Card(Suit.Spade, this.Value + 1);
            this.PlayOnWork.Add(card1);
            this.PlayOnWork.Add(card2);
        }
    }

    public Card(Suit suit, int value)
    {
        this.Suit = suit;
        this.Value = value;
    }

    public override string ToString()
    {
        return $"{this.Value.ToString()}-{this.Suit.ToString()}"; 
    }

    public override bool Equals(Object obj)
    {
        Card other = obj as Card;
        if (other == null)
            return false;

        return this.Value == other.Value && this.Suit == other.Suit;
    }

    public override int GetHashCode()
    {
        return CultureInfo.CurrentCulture == null ? 0 : CultureInfo.CurrentCulture.GetHashCode();
    }
}
