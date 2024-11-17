using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClinicaUniversitaria.Data
{
    public class ClinicaContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }

        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {
            // Asegura que la base de datos está creada
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Ruta de la base de datos SQLite
                string dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "clinica.db3");
                optionsBuilder.UseSqlite($"Filename={dbPath}");
            }
        }
    }
}
