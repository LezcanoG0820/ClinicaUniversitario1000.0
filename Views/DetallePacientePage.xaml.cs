using Microsoft.Maui.Controls;
using ClinicaUniversitaria.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ClinicaUniversitaria.Views
{
    public partial class DetallePacientePage : ContentPage
    {
        private readonly Paciente _paciente;
        private readonly ClinicaContext _context;

        public DetallePacientePage(Paciente paciente, ClinicaContext context)
        {
            InitializeComponent();
            _paciente = paciente ?? throw new ArgumentNullException(nameof(paciente));
            _context = context ?? throw new ArgumentNullException(nameof(context));

            // Cargar datos del paciente en los campos
            CargarDatosPaciente();
        }

        private void CargarDatosPaciente()
        {
            if (_paciente != null)
            {
                NombreEntry.Text = _paciente.Nombre;
                IdentificacionEntry.Text = _paciente.Identificacion;
                ContactoEntry.Text = _paciente.Contacto;
                HistorialMedicoEditor.Text = _paciente.HistorialMedico;
            }
        }

        private async void OnActualizarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
                string.IsNullOrWhiteSpace(IdentificacionEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete los campos obligatorios.", "OK");
                return;
            }

            try
            {
                _paciente.Nombre = NombreEntry.Text;
                _paciente.Contacto = ContactoEntry.Text;
                _paciente.HistorialMedico = HistorialMedicoEditor.Text ?? string.Empty;

                _context.Pacientes.Update(_paciente);
                await _context.SaveChangesAsync();

                await DisplayAlert("Éxito", "Paciente actualizado correctamente.", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al actualizar el paciente: {ex.Message}", "OK");
            }
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirmar",
                "¿Está seguro de que desea eliminar este paciente?", "Sí", "No");

            if (confirm)
            {
                try
                {
                    _context.Pacientes.Remove(_paciente);
                    await _context.SaveChangesAsync();

                    await DisplayAlert("Éxito", "Paciente eliminado correctamente.", "OK");
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error",
                        $"Ocurrió un error al eliminar el paciente: {ex.Message}", "OK");
                }
            }
        }
    }
}