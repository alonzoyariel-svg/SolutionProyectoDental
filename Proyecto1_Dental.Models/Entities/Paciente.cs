using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Dental.Models.Entities
{
    public class Paciente
    {
        [Key]
        public int PacienteID { get; set; }

        [Required, MaxLength(80)]
        public string Nombre { get; set; }

        [Required, MaxLength(80)]
        public string Apellido { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(200)]
        public string Correo { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
