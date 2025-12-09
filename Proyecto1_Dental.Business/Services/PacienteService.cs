using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1_Dental.Models.Entities;
using Proyecto1_Dental.Business.Services; 
using Proyecto1_Dental.Business; 

namespace Proyecto1_Dental.Business.Services
{
    
    public class PacienteService
    {
        private readonly BaseService<Paciente> _baseService;

        public PacienteService()
        {
            _baseService = new BaseService<Paciente>(); 
        }

        public List<Paciente> ObtenerTodos()
        {
            return _baseService.GetAllAsync().Result;
        }

        public Paciente Crear(Paciente entidad)
        {
            return _baseService.AddAsync(entidad).Result;
        }

        public Paciente Actualizar(Paciente entidad)
        {
            return _baseService.UpdateAsync(entidad).Result;
        }

        public bool Eliminar(int id)
        {
            return _baseService.DeleteAsync(id).Result;
        }

        public List<Paciente> Buscar(string nombre)
        {
            var lista = _baseService.GetAllAsync().Result;
            if (string.IsNullOrWhiteSpace(nombre)) return lista;
            return lista.Where(p => p.Nombre != null && p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }
}
