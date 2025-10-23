namespace E_commerce;

public class CartService
{
    public List<Product> AvailableProducts { get; } = new()
    {
        new Product("Converse", 599m, 1),
        new Product("Cheap Monday Slim Jeans", 399m,2),
        new Product("Jacket",499m,3)
    };
    public List<Product> Cart { get; } = new();
    public IEnumerable<string> GetProductDescriptions()
    {
        return AvailableProducts.Select(p => 
                $"Article: #{p.ArticleNumber}, {p.Name}, Price: {p.Price}kr");
    }
    public bool TryAddToCart(int quantity)
    {
        if (quantity >= 0 && quantity < AvailableProducts.Count)
        {
            Cart.Add(AvailableProducts[quantity]);
            return true;
        }
        return false;
    }
    public IEnumerable<Product> GetCartItems() => Cart;
    public decimal GetCartTotal() => Cart.Sum(p => p.Price);
    public Order CreateOrder()
    {
        var order = new Order();
        order.Items.AddRange(Cart);
        Cart.Clear();
        return order;
    }
}