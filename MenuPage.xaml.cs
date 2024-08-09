using Microsoft.Maui.Controls;
using RestoranAplikacijaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestoranAplikacijaV2.Pages
{
    public partial class MenuPage : ContentPage
    {
        private int tableNumber;

        public List<Category> Categories { get; set; }

        public MenuPage(int tableNumber)
        {
            InitializeComponent();
            this.tableNumber = tableNumber;
            Categories = GetCategories();
            BindingContext = this;
        }

        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "Pizza",
                    Items = new List<Item>
                    {
                        new Item { Name = "Margherita", Description = "Pizza sa sirom i paradajz sosom.", Price = 9.0m, ImageSource = "Images/margarita.jpg" },
                        new Item { Name = "Cappriciosa", Description = "Pizza sa sunkom i gljivama.", Price = 10.0m, ImageSource = "Images/kapricoza.jpg" },
                        new Item { Name = "Funghi", Description = "Pizza sa gljivama.", Price = 9.5m, ImageSource = "Images/fungi.jpg" }
                    }
                },
                new Category
                {
                    Name = "Jela sa roštilja",
                    Items = new List<Item>
                    {
                        new Item { Name = "Pljeskavica", Description = "Ukusna pljeskavica s roštilja.", Price = 5.0m, ImageSource = "Images/pljeskavica.jpg" },
                        new Item { Name = "Ćevapi", Description = "Ćevapi s lukom.", Price = 7.0m, ImageSource = "Images/cevapi.jpg" },
                        new Item { Name = "Kobasica", Description = "Domaća kobasica.", Price = 4.0m, ImageSource = "Images/kobasica.jpg" }
                    }
                },
                new Category
                {
                    Name = "Piće",
                    Items = new List<Item>
                    {
                        new Item { Name = "Kisela voda", Description = "Osvježavajuće gazirano piće.", Price = 2.0m, ImageSource = "Images/kisela.jpg" },
                        new Item { Name = "Senzacija", Description = "Sve vrste senzacije Sarajevskog kiseljaka.", Price = 2.5m, ImageSource = "Images/senzacija.jpg" },
                        new Item { Name = "Voda", Description = "Prirodna voda.", Price = 2.0m, ImageSource = "Images/voda.jpg" }
                    }
                }
            };
        }

        private void OnAddToCartClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.BindingContext as Item;

            if (item != null)
            {
                ((App)Application.Current).AddToCart(item);
            }
            
        }
        

            private async void OnCartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(((App)Application.Current).GetCartItems(), tableNumber));
        }
    }
}
