using Proyecto1_Dental.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Dental.Data.Context
{
    public class DentalDbContext : DbContext
    {
        public DentalDbContext() : base("name=DentalDb")
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Motivo> Motivos { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
}
