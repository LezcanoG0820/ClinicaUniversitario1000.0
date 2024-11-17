using ClinicaUniversitaria.Data;
using ClinicaUniversitaria.Views;
using Microsoft.EntityFrameworkCore;

namespace ClinicaUniversitaria
{
    public partial class App : Application
    {
        public ClinicaContext Database { get; }

        public App(ClinicaContext context)
        {
            InitializeComponent();

            Database = context;

            // Configurar la navegación
            MainPage = new NavigationPage(new MainPage(Database));
        }
    }
}
