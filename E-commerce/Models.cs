namespace E_commerce;

public class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public int ArticleNumber { get; }
    
    public Product(string name, decimal price, int articleNumber)
    {
        Name = name;
        Price = price;
        ArticleNumber = articleNumber;
    }
}

public class Order
{
    public List<Product> Items { get; } = new();
    public decimal Total => Items.Sum(item => item.Price);

    public IEnumerable<string> GenerateReceiptLines()
    {
        yield return $"Order Total: {Total:C}";
        foreach (var item in Items)
        {
            yield return $"Confirmed order: Article #{item.ArticleNumber} {item.Name}: {item.Price:C}";
        }
    }
}
