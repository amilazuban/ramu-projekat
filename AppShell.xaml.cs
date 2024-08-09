using Microsoft.Maui.Controls;
using RestoranAplikacijaV2.Pages;

namespace RestoranAplikacijaV2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Definisanje rutiranja
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
        }
    }
}
