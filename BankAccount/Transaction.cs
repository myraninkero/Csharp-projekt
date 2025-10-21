namespace BankAccount;

public class Transaction
{
    public DateTime Timestamp { get; }
    public string Type { get; }
    public decimal Amount { get; }
    public decimal BalanceAfter { get; }

    public Transaction(string type, decimal amount, decimal balanceAfter)
    {
        Timestamp = DateTime.Now;
        Type = type;
        Amount = amount;
        BalanceAfter = balanceAfter;
    }
    public override string ToString()
    {
        return $"{Timestamp:G} | {Type} | {Amount:C} | Balance: {BalanceAfter:C}";
    }
}