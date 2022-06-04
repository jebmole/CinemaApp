using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Domain.Interfaces
{
    public interface ISalaRepository
    {
        Sala GetSalaById(int idSala);
        IEnumerable<Sala> GetSalas();

        void InsertSala(Sala sala);

        void UpdateSala(Sala sala);

        void DeleteSala(int idSala);
    }
}
