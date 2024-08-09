using Microsoft.Maui.Controls;
using System;

namespace RestoranAplikacijaV2.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnContinueClicked(object sender, EventArgs e)
        {
            if (int.TryParse(TableNumberEntry.Text, out int tableNumber))
            {
                await Navigation.PushAsync(new MenuPage(tableNumber));
            }
            else
            {
                await DisplayAlert("Greška", "Molimo unesite validan broj stola.", "OK");
            }
        }
    }
}
