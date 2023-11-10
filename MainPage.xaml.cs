namespace Ejercicio_1._3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void listadatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var elemento = e.CurrentSelection.FirstOrDefault() as Models.Persona;
            if (elemento != null)
            {
                Navigation.PushAsync(new Views.UpdateDeletePage
                {
                    BindingContext = elemento
                });
            }



        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listadatos.ItemsSource = await App.PersonRepo.GetAllPersonas();
        }

        private async void toolagrega_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.DatosPage());

        }
    }
}