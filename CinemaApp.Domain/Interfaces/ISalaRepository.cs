using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface ISalaRepository
    {
        IEnumerable<Sala> GetSalas();

        void InsertSala(Sala sala);

        void UpdateSala(Sala sala);
    }
}
