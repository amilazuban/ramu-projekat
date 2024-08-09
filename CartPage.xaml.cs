using Microsoft.Maui.Controls;
using RestoranAplikacijaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestoranAplikacijaV2.Pages
{
    public partial class CartPage : ContentPage
    {
        public List<Item> CartItems { get; set; }
        public decimal TotalPrice => CartItems.Sum(item => item.Price);
        private int tableNumber;

        public CartPage(List<Item> cartItems, int tableNumber)
        {
            InitializeComponent();
            CartItems = cartItems;
            this.tableNumber = tableNumber;
            BindingContext = this;
        }

        async void OnCheckoutButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Narudžba", $"Vaša narudžba je zaprimljena za stol broj {tableNumber}.", "OK");
        }

        async void OnBackToMenuButtonClicked(object sender, EventArgs e)
        {
            try
            {
                ((App)Application.Current).ClearCart();

                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Greška", $"Došlo je do greške: {ex.Message}", "OK");
            }
        }
        async void OnRemoveFromCartClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.CommandParameter as Item;

            if (item != null)
            {
                CartItems.Remove(item);
                BindingContext = null;
                BindingContext = this;
            }
        }

    }
}
