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
	public partial class ConfirmacionPage : ContentPage
	{
		public ConfirmacionPage (Funciones funcion, Peliculas pelicula, int valor)
        {
            InitializeComponent();
            int valortotal = valor * funcion.Precio;
            peliculaStack.BindingContext = pelicula;
            layoutfuncion.BindingContext = funcion;
            lblcantidad.Text = Convert.ToString(valor);
            total.Text = Convert.ToString(valortotal);
        }

        private void BtnConfirmar(object sender, EventArgs e)
        {
            DisplayAlert("Compra", "La reserva se ha generado correctamente", "Ok");
        }
    }
}