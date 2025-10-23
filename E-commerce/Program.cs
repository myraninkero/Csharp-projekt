namespace E_commerce;

class Program
{
    static void Main(string[] args)
    {
        var cartService = new CartService();
        bool running = true;

        while (running)
        {
            ShowMenu();
            string input = Console.ReadLine();
            
            Console.Clear();
            switch (input)
            {
                case "1":
                    foreach (var product in cartService.GetProductDescriptions())
                        Console.WriteLine(product);
                    break;
                case "2":
                    Console.WriteLine("Select a product (Article: #): ");
                    if (int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        bool success = cartService.TryAddToCart(quantity - 1);
                        Console.WriteLine(success ? "Product added to cart" : "Product not added to cart");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                    break;
                case "3":
                    var items = cartService.GetCartItems();
                    if (!items.Any())
                    {
                        Console.WriteLine("Your cart is empty");
                    }
                    else
                    {
                        foreach (var item in items)
                            Console.WriteLine($"Article #{item.ArticleNumber} {item.Name}: {item.Price:C}");
                        Console.WriteLine($"Total: {cartService.GetCartTotal():C}");
                    }
                    break;
                case "4":
                    var cartItems = cartService.GetCartItems();
                    if (!cartItems.Any())
                    {
                        Console.WriteLine("You must add at least one product before checkout.");
                        break;
                    }
                    
                    foreach (var item in cartItems)
                        Console.WriteLine($"Article #{item.ArticleNumber} {item.Name}: {item.Price:C}");
                    Console.WriteLine($"Total: {cartService.GetCartTotal():C}");
                    
                    Console.Write("Confirm order? (Y/N): ");
                    string confirm = Console.ReadLine()?.ToUpper();
                    if (confirm == "Y")
                    {
                        var order = cartService.CreateOrder();
                        foreach (var product in order.GenerateReceiptLines())
                            Console.WriteLine(product);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Thank you for shopping!");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
    static void ShowMenu()
    {
        Console.WriteLine("\n--- Main Menu ---");
        Console.WriteLine("1. View products");
        Console.WriteLine("2. Add product to cart");
        Console.WriteLine("3. View cart");
        Console.WriteLine("4. Proceed to checkout");
        Console.WriteLine("5. Exit");
        Console.Write("Your choice: ");
    }
}

/*
 * START

1. Skapa en lista med tillgängliga produkter (namn + pris) [X]

2. Skapa en tom varukorg (lista av produkter) [X]

3. Visa huvudmeny: [X]
   - 1. Visa produkter
   - 2. Lägg till produkt i varukorg
   - 3. Visa varukorg
   - 4. Gå till kassan
   - 5. Avsluta

4. LOOP så länge användaren inte väljer "Avsluta": [X]
   - Läs användarens val

   - Om val == 1:
       Visa alla produkter med nummer och pris

   - Om val == 2:
       Be användaren välja produktnummer
       Lägg vald produkt i varukorgen
       Bekräfta att produkten lades till

   - Om val == 3:
       Visa innehållet i varukorgen

   - Om val == 4:
       Om varukorgen är tom:
           Visa meddelande: "Du måste lägga till minst en produkt"
       Annars:
           Visa alla produkter i varukorgen
           Visa totalbelopp
           Fråga: Vill du bekräfta ordern? (J/N)
           Om J:
               Skapa order (t.ex. skriv ut kvitto)
               Töm varukorgen
               Visa tackmeddelande
           Om N:
               Gå tillbaka till huvudmenyn

   - Om val == 5:
       Avsluta programmet
       
BONUS:
    1. Moms per produkt
    
    2 Inköpspris och vinstberäkning
    
    3 Orderhistorik
    
    4 Varav moms i kvitto
    
    5 Adminfunktion för vinst

END

 */