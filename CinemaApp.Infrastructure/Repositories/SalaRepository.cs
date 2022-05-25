using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Interfaces;
using CinemaApp.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
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
    }
}
