namespace Blackjack;

public class Player
{
    public string Name { get; }
    public List<Card> Hand { get; private set; }

    public Player(string name) // Konstruktor skickar in ett namn och får en tom hand. (Hand = new List<Card>())
    {
        Name = name;
        Hand = new List<Card>();
    }

    public void AddCard(Card card) // Lägger till ett kort i spelaren hand
    {
        Hand.Add(card);
    }

    public int GetScore() // Poäng räknare
    {
        int total = Hand.Sum(c => c.Value); // Summerar alla kortens värden
        int aceCount = Hand.Count(c => c.Rank == "A"); // Räknar hur många ess det finns

        while (total > 21 && aceCount > 0) // Om totalen är över 21 och det finns ess, justerar ess från 11 till 
        {
            total -= 10;
            aceCount--;
        }

        return total;
    }
    
    public void ShowHand(bool revealAll = true) // Skriver ut spelarens hand
    {
        Console.WriteLine($"{Name} hand:");
        for (int i = 0; i < Hand.Count; i++)
        {
            if (!revealAll && i == 1 &&
                Name == "Dealer") // - Om revealAll är false och spelaren är "Dealer" så döljs ett kort
                Console.WriteLine("Gömt kort");
            else
                foreach (string line in Hand[i].GetAsciiLines())
                {
                    Console.WriteLine(line);
                }

        }

        if (revealAll) // Visar alla kort och totalpoäng
            Console.WriteLine($"Total: {GetScore()}\n");
    }

    public void ResetHand()
    {
        Hand.Clear();
    }
    
    public int GetVisibleScore()
    {
        if (Name != "Dealer" || Hand.Count == 0)
            return GetScore(); // För vanliga spelare eller tom hand

        return Hand[0].Value; // Bara första kortets poäng
    }

    
    public void ShowHandAscii(bool revealAll = true)
    {
        if (!revealAll && Name == "Dealer")
        {
            Console.WriteLine("Dealerns hand:");
            var firstCard = Hand[0].GetAsciiLines();
            var hiddenCard = new string[]
            {
                "┌─────────┐",
                "│░░░░░░░░░│",
                "│░░░░░░░░░│",
                "│░░ GÖMT ░│",
                "│░░░░░░░░░│",
                "│░░░░░░░░░│",
                "└─────────┘"
            };

            for (int i = 0; i < firstCard.Length; i++)
            {
                Console.WriteLine(firstCard[i] + " " + hiddenCard[i]);
            }
            Console.WriteLine($"Total: {GetVisibleScore()}\n");
        }
        else
        {
            Console.WriteLine($"{Name} hand:");

            var allLines = Hand.Select(card => card.GetAsciiLines()).ToList();

            for (int line = 0; line < 7; line++)
            {
                foreach (var cardLines in allLines)
                {
                    Console.Write(cardLines[line] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Total: {GetScore()}\n");
        }
    }


}