namespace Blackjack;

public class Game
{
    private Deck deck;
    private Player player;
    private Player dealer;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("Välkommen till Blackjack!\n" +
                          "Målet är att du ska komma så nära 21 som möjligt.\n" +
                          "Men kommer du över eller om dealern kommer närmare så har du förlorat.\n");

        deck = new Deck();
        player = new Player("Din");
        dealer = new Player("Dealer");

        player.ResetHand();
        dealer.ResetHand();

        player.AddCard(deck.Draw());
        player.AddCard(deck.Draw());
        dealer.AddCard(deck.Draw());
        dealer.AddCard(deck.Draw());

        player.ShowHandAscii();
        dealer.ShowHandAscii(false);


        PlayerTurn();
        if (player.GetScore() <= 21)
        {
            DealerTurn();
        }

        DetermineWinner();
        AskReplay();
    }
    private void PlayerTurn()
    {
        while (true)
        {
            Console.Write("Vill du [T]a ett kort eller [S]tanna? ");
            string input = Console.ReadLine()?.ToLower();
            Thread.Sleep(1500);

            if (input == "t")
            {
                player.AddCard(deck.Draw());
                player.ShowHandAscii();

                if (player.GetScore() > 21)
                {
                    Console.WriteLine("Du blev tjock!");
                    break;
                }
            }
            else if (input == "s")
            {
                Console.WriteLine("Du stannar.");
                break;
            }
        }
    }
    
    private void DealerTurn()
    {
        Console.WriteLine("\nDealerns tur:");
        dealer.ShowHandAscii();

        while (dealer.GetScore() < 17)
        {
            Console.WriteLine("Dealer drar ett kort...");
            Thread.Sleep(1500);
            dealer.AddCard(deck.Draw());
            dealer.ShowHandAscii();
        }

        if (dealer.GetScore() > 21)
        {
            Console.WriteLine("Dealern blev tjock!");
        }
    }
    
    private void DetermineWinner()
    {
        int playerScore = player.GetScore();
        int dealerScore = dealer.GetScore();

        Console.WriteLine("\nResultat:");
        player.ShowHandAscii();
        dealer.ShowHandAscii();

        if (playerScore > 21)
            Console.WriteLine("Du förlorade.");
        else if (dealerScore > 21 || playerScore > dealerScore)
            Console.WriteLine("Du vann!");
        else if (playerScore < dealerScore)
            Console.WriteLine("Du förlorade.");
        else
            Console.WriteLine("Oavgjort.");
    }
    private void AskReplay()
    {
        Console.Write("\nVill du spela igen? [J/N] ");
        string input = Console.ReadLine()?.ToLower();

        if (input == "j")
        {
            Start(); // Startar ny omgång
        }
        else
        {
            Console.WriteLine("Tack för att du spelade!");
        }
    }

}