using Cinema_AGV.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_AGV.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void Api(object sender, EventArgs e)
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var content = new StringContent("Usuario:" + usuario.Text + "&Password:" + password.Text, Encoding.UTF8, "application/json");

            var request = cliente.PostAsync("/api/Seguridad", content).Result;
            if (request.IsSuccessStatusCode)
            {
                var respuestaJson = await request.Content.ReadAsStringAsync();
                
                var autentificacion = JsonConvert.DeserializeObject<Usuario>(respuestaJson);
                if (autentificacion.EsPermitido == true)
                {
                    await DisplayAlert("Resultado", autentificacion.Mensaje, "Continuar");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Incorrecto", "Los datos no son validos", "Reintentar");
                }
            }
        }
    }
}