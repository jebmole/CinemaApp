using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaApp.Infrastructure.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private CinemaContext _context;
        public SalaRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Sala> GetSalas()
        {
            return _context.Sala;
        }

        public void InsertSala(Sala sala)
        {
            _context.Sala.Add(sala);
            _context.SaveChanges();
        }

        public void UpdateSala(Sala sala)
        {
            var salaExistente = _context.Sala.FirstOrDefault(x => x.IdSala == sala.IdSala);
            salaExistente.EsDinamix = sala.EsDinamix;
            salaExistente.Nomenclatura = sala.Nomenclatura;
            salaExistente.Capacidad = sala.Capacidad;
            salaExistente.Activa = sala.Activa;
            _context.SaveChanges();
        }
    }
}
