using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClinicaUniversitaria.Data
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Identificacion { get; set; }
        public string Contacto { get; set; }
        public string HistorialMedico { get; set; }
    }
}
