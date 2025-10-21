namespace BankAccount;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        bool exitProgram = false;
        while (!exitProgram)
        {
            BankAccount account = null;
            while (account == null)
            {
                Console.WriteLine("\n1. Create account");
                Console.WriteLine("2. Log in to account");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                Console.Write("Enter personal number: [YYYYMMDDXXXX] ");
                string personalNumber = Console.ReadLine();

                Console.Write("Enter your name (e.g. Cloud Strife): ");
                string name = Console.ReadLine();

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
            bool loggedIn = true;
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
                    var amount = decimal.Parse(Console.ReadLine());
                    var newBalance = account.Deposit(amount);
                    Console.WriteLine($"New balance: {newBalance}kr");
                }
                else if (choice == "2")
                {
                    Console.Write("Enter amount to withdraw: ");
                    var amount = decimal.Parse(Console.ReadLine());
                    var newBalance = account.Withdraw(amount);
                    if (account.GetBalance() < 0)
                    {
                        Console.WriteLine("Insufficient funds. Transaction cancelled.");
                        account.Deposit(amount);
                    }
                    else Console.WriteLine($"New balance: {newBalance}kr");
                }
                else if (choice == "3")
                {
                    var balance = account.GetBalance();
                    Console.WriteLine($"Current balance: {balance}kr");
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