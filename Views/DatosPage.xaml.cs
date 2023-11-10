using Ejercicio_1._3.Models;

namespace Ejercicio_1._3.Views;

public partial class DatosPage : ContentPage
{
	public DatosPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var data = new Persona
        {
            Nombre = nombre.Text,
            Apellidos = apellidos.Text,
            Edad = edad.Text,
            Correo = correo.Text,
            Direccion = direccion.Text
        };

        if (await App.PersonRepo.StoreDatos(data) > 0)
        {
            await DisplayAlert("Aviso", "Ingresado", "Ok");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Aviso", "No Ingresado", "Ok");
        }


    }
}