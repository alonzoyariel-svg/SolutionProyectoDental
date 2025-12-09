using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Dental.Models.Entities
{
    public class Cita
    {
        [Key]
        public int CitaID { get; set; }

        [Required]
        public int PacienteID { get; set; }

        [Required]
        public int DentistaID { get; set; }

        [Required]
        public int MotivoID { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Hora { get; set; }

        [Required]
        public int DuracionMinutos { get; set; }


        [NotMapped]
        public TimeSpan TiempoRestante
        {
            get
            {
                DateTime fechaCita = Fecha.Date + Hora;
                if (fechaCita < DateTime.Now) return TimeSpan.Zero;
                return fechaCita - DateTime.Now;
            }
        }

        [NotMapped]
        public string Estado
        {
            get
            {
                DateTime inicio = Fecha.Date + Hora;
                DateTime fin = inicio.AddMinutes(DuracionMinutos);

                if (DateTime.Now < inicio)
                    return "Vigente";

                if (DateTime.Now >= inicio && DateTime.Now <= fin)
                    return "En proceso";

                return "Finalizado";
            }
        }
    }
}
