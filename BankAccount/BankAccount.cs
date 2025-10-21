namespace BankAccount;

public class BankAccount
{
    public string Owner { get; }
    private decimal _balance;
    public string AccountNumber { get; set; }
    private List<Transaction> _transactions = new();
    public BankAccount(string owner, string accountNumber)
    {
        Owner = owner;
        _balance = 0m;
        AccountNumber = accountNumber;
    }
    public double Withdraw(decimal amount)
    {
        _balance -= amount;
        _transactions.Add(new Transaction("Withdraw", amount, _balance));
        return GetBalance();
    }
    public double Deposit(decimal amount)
    {
        _balance += amount;
        _transactions.Add(new Transaction("Deposit", amount, _balance));
        return GetBalance();
    }
    public double GetBalance()
    {
        return (double) Math.Round(_balance, 2);
    }
    public IReadOnlyList<Transaction> GetTransactions()
    {
        return _transactions.AsReadOnly();
    }
}