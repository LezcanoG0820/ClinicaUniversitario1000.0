using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using ClinicaUniversitaria.Data;
using CommunityToolkit.Maui;

namespace ClinicaUniversitaria
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
            // Registrar el contexto de la base de datos
            builder.Services.AddDbContext<ClinicaContext>();
            // Registrar las páginas
            builder.Services.AddTransient<Views.RegistroPacientePage>();
            builder.Services.AddTransient<Views.ListaPacientesPage>();
            builder.Services.AddTransient<Views.DetallePacientePage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}