namespace Blackjack;

public class Card
{
    public string Suit { get; }     // Lagrar färg: Hjärter, Spader, etc.
    public string Rank { get; }     // Lagrart värde: 2–10, J, Q, K, A
    public int Value { get; }       // Lagrar poängvärde: 2–11

    public Card(string suit, string rank, int value) // Konstruktor körs när ett nytt kort skapas (skickar in färg, värde och poängvärde och sparar dessa)
    {
        Suit = suit;
        Rank = rank;
        Value = value;
    }

    public override string ToString()  // En metod som gör att kortet kan skrivas ut snyggt i konsolen. Istället för att visa typnamn (Card), visas tex: "K av Hjärter".

    {
        return $"{Rank} av {Suit}";
    }
    
    public string[] GetAsciiLines()
    {
        string rankDisplay = Rank.PadRight(2);
        string suitSymbol = Suit switch
        {
            "Hjärter" => "♥",
            "Spader"  => "♠",
            "Ruter"   => "♦",
            "Klöver"  => "♣",
            _ => "?"
        };

        return new string[]
        {
            "┌─────────┐",
            $"│{rankDisplay}       │",
            "│         │",
            $"│    {suitSymbol}     │",
            "│         │",
            $"│       {rankDisplay}│",
            "└─────────┘"
        };
    }

}