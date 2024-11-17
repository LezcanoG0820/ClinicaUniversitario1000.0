using ClinicaUniversitaria.Data;
using ClinicaUniversitaria.Views;
using Microsoft.Maui.Controls;

namespace ClinicaUniversitaria
{
    public partial class MainPage : ContentPage
    {
        private readonly ClinicaContext _context;

        public MainPage(ClinicaContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void OnRegistrarPacienteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPacientePage(_context));
        }

        private async void OnVerListaPacientesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPacientesPage(_context));
        }
    }
}
