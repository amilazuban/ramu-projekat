using Microsoft.Maui.Controls;
using RestoranAplikacijaV2.Models;
using System.Collections.Generic;

namespace RestoranAplikacijaV2.Pages
{
    public partial class CategoryPage : ContentPage
    {
        public List<Item> Items { get; set; }

        public CategoryPage(Category category)
        {
            InitializeComponent();
            Items = category.Items;
            BindingContext = this;
        }

        void OnAddToCartClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.CommandParameter as Item;

            if (item != null)
            {
                ((App)Application.Current).AddToCart(item);
                DisplayAlert("Dodano u korpu", $"{item.Name} je dodan/a u korpu.", "OK");
            }
        }
    }
}
