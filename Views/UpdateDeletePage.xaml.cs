using Ejercicio_1._3.Models;

namespace Ejercicio_1._3.Views;

public partial class UpdateDeletePage : ContentPage
{
	public UpdateDeletePage()
	{
		InitializeComponent();
	}

    private async void btnactualizar_Clicked(object sender, EventArgs e)
    {
        var data = new Persona
        {
            Id = Int32.Parse(id.Text),
            Nombre = nombre.Text,
            Apellidos = apellidos.Text,
            Edad = edad.Text,
            Correo = correo.Text,
            Direccion = direccion.Text
        };

        if (await App.PersonRepo.StoreDatos(data) > 0)
        {
            await DisplayAlert("Alerta", "Datos actualizados", "Ok");

            id.Text = "";
            nombre.Text = "";
            apellidos.Text = "";
            edad.Text = "";
            correo.Text = "";
            direccion.Text = "";

            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "No se pudo actualizar", "Ok");
        }
    }

    private void btneliminar_Clicked(object sender, EventArgs e)
    {
        OnAlertYesNoClicked(sender, e);
    }

    async void OnAlertYesNoClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Alerta", "Eliminar Datos?", "Si", "No");

        if (answer == true)
        {
            var data = new Persona
            {
                Id = Int32.Parse(id.Text)
            };

            if (await App.PersonRepo.DeleteDatos(data) > 0)
            {
                await DisplayAlert("Alerta", "Datos eliminados", "Ok");

                id.Text = "";
                nombre.Text = "";
                apellidos.Text = "";
                edad.Text = "";
                correo.Text = "";
                direccion.Text = "";

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "No se puede eliminar", "Ok");
            }

        }
    }
}