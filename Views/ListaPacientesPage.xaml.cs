using Microsoft.Maui.Controls;
using ClinicaUniversitaria.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace ClinicaUniversitaria.Views
{
    public partial class ListaPacientesPage : ContentPage
    {
        private readonly ClinicaContext _context;

        public ListaPacientesPage(ClinicaContext context)
        {
            InitializeComponent();
            _context = context;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CargarPacientes();
        }

        private async Task CargarPacientes()
        {
            try
            {
                var pacientes = await _context.Pacientes.ToListAsync();
                PacientesListView.ItemsSource = pacientes;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al cargar pacientes: {ex.Message}", "OK");
            }
        }

        private async void OnPacienteSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Paciente selectedPaciente)
            {
                await Navigation.PushAsync(new DetallePacientePage(selectedPaciente, _context));
                PacientesListView.SelectedItem = null;
            }
        }
    }
}