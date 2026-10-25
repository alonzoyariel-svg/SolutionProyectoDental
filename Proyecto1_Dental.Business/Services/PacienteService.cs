using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto1_Dental.Models.Entities;

namespace Proyecto1_Dental.Business.Services
{
    public class PacienteService
    {
        private readonly BaseService<Paciente> _baseService = new BaseService<Paciente>();

        public Task<List<Paciente>> ObtenerTodosAsync()
        {
            return _baseService.GetAllAsync();
        }

        public Task<Paciente> CrearAsync(Paciente entidad)
        {
            return _baseService.AddAsync(entidad);
        }

        public Task<Paciente> ActualizarAsync(Paciente entidad)
        {
            return _baseService.UpdateAsync(entidad);
        }

        public Task<bool> EliminarAsync(int id)
        {
            return _baseService.DeleteAsync(id);
        }

        public async Task<List<Paciente>> BuscarAsync(string nombre)
        {
            var lista = await _baseService.GetAllAsync();
            if (string.IsNullOrWhiteSpace(nombre)) return lista;

            return lista.Where(p => p.Nombre != null &&
                p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }
}
