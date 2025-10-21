namespace Blackjack;

public class Deck
{
    private List<Card> cards; // Använder List för man ska kunna lägga till, ta bort och blanda.
    private Random rng = new Random(); // Skapar metod för att blanda korten

    public Deck() // Konstruktor för en ny kortlek
    {
        Reset();
    }

    public void Reset() // Skapar en ny kortlek
    {
        cards = new List<Card>(); // Kortlek skapas
        string[] suits = {"Hjärter", "Ruter", "Spader", "Klöver"}; // Alla färger i en lista (suits)
        string[] ranks = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"}; // Alla värden i en lista (ranks)

        foreach (var suit in suits) // För varje färger i listan suits (string[] suits)
        {
            foreach (var rank in ranks) // För varje rank i listan ranks (string[] ranks)
            {
                int value = rank switch // Varje rank får ett värde (value)
                {
                    "J" or "Q" or "K" => 10, // Klädda kort = 10
                    "A" => 11, // Ess = 11
                    _ => int.Parse(rank) // Konverterar string till int
                };
                cards.Add(new Card(suit, rank, value)); // Lägger till korten i listan (cards)
            }
        }

        shuffle(); // Anropar kortblandaren efter att varje kort fått ett värde
    }

    private void shuffle() // Kortblandare
    {
        cards = cards.OrderBy(c => rng.Next()).ToList(); // Blandar alla korten listan (cards)
    }

    public Card Draw() // Drar kort
    {
        if (cards.Count == 0) // Om kortleken är tom skapas de ett nytt
        {
            Reset();
        }

        Card top = cards[0]; // Översta kortet i kortleken
        cards.RemoveAt(0);
        return top; // Returnerar det första kortet och tar bort den från listan (cards.RemoveAt(0);)
    }
}