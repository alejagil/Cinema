using Cinema_AGV.Models;
using Cinema_AGV.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cinema_AGV
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            CargarPeliculas();
           
		}

       

        private async void CargarPeliculas()
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");
            var request = await cliente.GetAsync("/api/Cartelera");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var peliculas = JsonConvert.DeserializeObject <List<Peliculas>>(responseJson);
               listPeliculas.ItemsSource = peliculas;
                
            }
        }

        private async void peliculaSeleccionada(object sender, SelectedItemChangedEventArgs e)
        {
            var pelicula = e.SelectedItem as Peliculas;
            await Navigation.PushAsync(new DetalleFunciones(pelicula));
        }
    }
}
