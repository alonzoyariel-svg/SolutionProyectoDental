using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Dental.Models.Entities
{
    public class Dentista
    {
        [Key]
        public int DentistaID { get; set; }

        [Required, MaxLength(80)]
        public string Nombre { get; set; }

        [Required, MaxLength(80)]
        public string Especialidad { get; set; }

        public bool Activo { get; set; } = true;
    }
}
