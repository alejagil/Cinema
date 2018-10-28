using Cinema_AGV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinema_AGV.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalleFunciones : ContentPage
	{
        Peliculas glopeliculas;
		public DetalleFunciones (Peliculas pelicula)
		{
			InitializeComponent ();
            BindingContext = pelicula;
            listDetalle.ItemsSource = pelicula.Funciones;
            glopeliculas = pelicula;
		}

        private async void DetalleSeleccionado(object sender, SelectedItemChangedEventArgs e)
        {
            
            var funcion = e.SelectedItem as Funciones;
            var entry = 0;
            entry = Convert.ToInt32(entry1.Text);
            if (entry == 0)
            {
                await DisplayAlert("Error","Ingrese la cantidad de boletas","Continuar");
            } else
            {
                await Navigation.PushAsync(new ConfirmacionPage(funcion, glopeliculas, entry));
            }
        }
    }
}