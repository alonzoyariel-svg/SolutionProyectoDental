using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Dental.Models.Entities
{
    public class Motivo
    {
        [Key]
        public int MotivoID { get; set; }

        [Required, MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
