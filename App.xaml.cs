using Microsoft.Maui.Controls;
using RestoranAplikacijaV2.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace RestoranAplikacijaV2
{
    public partial class App : Application
    {
        public List<Item> Cart { get; private set; } = new List<Item>();

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        public void AddToCart(Item item)
        {
            Cart.Add(item);
        }

        public void RemoveFromCart(Item item)
        {
            Cart.Remove(item);
        }

        public void ClearCart()
        {
            Cart.Clear();
        }

        public List<Item> GetCartItems()
        {
            return Cart;
        }

        public decimal GetTotalPrice()
        {
            return Cart.Sum(i => i.Price);
        }

        public string GenerateOrderJson()
        {
            var order = new Order { Items = Cart };
            return JsonSerializer.Serialize(order);
        }
    }
}
