using BlazorAppDemo.Components.Model;

namespace BlazorAppDemo.Components.Service
{
    public class CartService
    {
        public List<Product> Items { get; set; } = new();

        public void Add(Product product)
        {
            Items.Add(product);
        }
    }
}