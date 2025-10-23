namespace BankAccount;

class Program
{
    static void Main(string[] args)
    {
        var bank = new Bank();
        var exitProgram = false;
        while (!exitProgram)
        {
            BankAccount account = null;
            while (account == null)
            {
                Console.WriteLine("\n1. Create account");
                Console.WriteLine("2. Log in to account");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                Console.Write("Enter personal number: [YYYYMMDDXXXX] ");
                var personalNumber = Console.ReadLine();

                Console.Write("Enter your name (e.g. Cloud Strife): ");
                var name = Console.ReadLine();

                if (choice == "1")
                {
                    try
                    {
                        account = bank.CreateAccount(personalNumber, name);
                        Console.WriteLine("Account created successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (choice == "2")
                {
                    account = bank.Login(personalNumber, name);
                    if (account != null)
                    {
                        Console.WriteLine($"Welcome back, {account.Owner}!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect name or personal number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                }
            }
            var loggedIn = true;
            while (loggedIn)
            {
                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Check Transactions");
                Console.WriteLine("5. Logout");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                {
                    Console.Write("Enter amount to deposit: ");
                    var depositAmount = decimal.Parse(Console.ReadLine());
                    var newBalance = account.Deposit(depositAmount);
                    Console.WriteLine($"New balance: {newBalance}kr");
                }
                else if (choice == "2")
                {
                    Console.Write("Enter amount to withdraw: ");
                    var withdrawAmount = decimal.Parse(Console.ReadLine());
                    var newBalance = account.Withdraw(withdrawAmount);
                    if (account.GetBalance() < 0)
                    {
                        Console.WriteLine("Insufficient funds. Transaction cancelled.");
                        account.Deposit(withdrawAmount);
                    }
                    else Console.WriteLine($"New balance: {newBalance}kr");
                }
                else if (choice == "3")
                {
                    Console.WriteLine($"Current balance: {account.GetBalance()}kr");
                }
                else if (choice == "4")
                {
                    foreach (var t in account.GetTransactions()) 
                        Console.WriteLine(t);
                }
                else if (choice == "5")
                {
                    loggedIn = false;
                    Console.WriteLine("You have been logged out.");
                }
                else if (choice == "6")
                {
                    Console.WriteLine("Thank you for banking with us!");
                    exitProgram = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }
            }
        }
    }
}