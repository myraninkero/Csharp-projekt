namespace BankAccount;

public class Bank
{
    private readonly Dictionary<string, BankAccount> _accounts = new();
    
    public BankAccount CreateAccount(string personalNumber, string name)
    {
        if (_accounts.ContainsKey(personalNumber))
        {
            throw new Exception("An account with this personal number already exists.");
        }

        var newAccount = new BankAccount(name, personalNumber);
        _accounts[personalNumber] = newAccount;
        return newAccount;
    }
    
    public BankAccount Login(string personalNumber, string name)
    {
        if (_accounts.ContainsKey(personalNumber))
        {
            var account = _accounts[personalNumber];

            if (account.Owner == name)
            {
                return account;
            }
        }
        return null;
    }
}

