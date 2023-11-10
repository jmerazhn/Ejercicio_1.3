namespace Ejercicio_1._3
{
    public partial class App : Application
    {

        public static PersonRepository PersonRepo { get; set; }
        public App(PersonRepository repo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            PersonRepo= repo;
        }
    }
}