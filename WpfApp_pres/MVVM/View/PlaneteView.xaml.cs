using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using App_PresApi.DTO;

namespace WpfApp_pres.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour PlaneteView.xaml
    /// </summary>
    public partial class PlaneteView : UserControl
    {
        public PlaneteView()
        {
            InitializeComponent();
        }

        private async void Button_ClickPL(object sender, RoutedEventArgs e)
        {
            // Générer un identifiant aléatoire
            Random random = new Random();
            int randomId = random.Next(1, 10);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5137/api/Planet/GetPlById/Planet/" + randomId);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var pl = await response.Content.ReadFromJsonAsync<PlanetDTO>();
                    NomPlanet.Content = pl.PlName;
                    OrbitPlanet.Content = pl.PlOrbper;
                    MassePLanet.Content = pl.PlBmasse;
                    DensitePlanet.Content = pl.PlDens;
                }
                else
                {
                    NomPlanet.Content = $"Error code {response.StatusCode}";
                }
            }
        }
    }
}
