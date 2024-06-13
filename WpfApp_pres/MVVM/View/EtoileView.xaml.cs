using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App_PresApi.DTO;
using Microsoft.AspNetCore.Connections;

namespace WpfApp_pres.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour Etoile.xaml
    /// </summary>
    public partial class Etoile : UserControl
    {
        public Etoile()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            // Générer un identifiant aléatoire
            Random random = new Random();
            int randomId = random.Next(1, 5);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5137/api/Star/GetStarById/"+randomId);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var star = await response.Content.ReadFromJsonAsync<StarDTO>();
                    NomEtoile.Content = star.Hostname;
                    SpecEtoile.Content = star.StSpectype;
                    AgeEtoile.Content = star.StAge;
                }
                else {

                    NomEtoile.Content = $"Error code {response.StatusCode}";
                
                }
            }
        }
    }
}