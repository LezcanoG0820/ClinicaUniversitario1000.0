using Microsoft.Maui.Controls;
using ClinicaUniversitaria.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ClinicaUniversitaria.Views
{
    public partial class RegistroPacientePage : ContentPage
    {
        private readonly ClinicaContext _context;

        public RegistroPacientePage(ClinicaContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void OnRegistrarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
                string.IsNullOrWhiteSpace(IdentificacionEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete los campos obligatorios.", "OK");
                return;
            }

            var nuevoPaciente = new Paciente
            {
                Nombre = NombreEntry.Text,
                Identificacion = IdentificacionEntry.Text,
                Contacto = ContactoEntry.Text,
                HistorialMedico = HistorialMedicoEditor.Text ?? string.Empty
            };

            try
            {
                _context.Pacientes.Add(nuevoPaciente);
                await _context.SaveChangesAsync();

                await DisplayAlert("Éxito", "Paciente registrado correctamente.", "OK");

                // Limpiar los campos
                NombreEntry.Text = string.Empty;
                IdentificacionEntry.Text = string.Empty;
                ContactoEntry.Text = string.Empty;
                HistorialMedicoEditor.Text = string.Empty;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al registrar el paciente: {ex.Message}", "OK");
            }
        }
    }
}