using CinemaApp.Application.Requests;
using CinemaApp.Application.Responses;
using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Application.Interfaces
{
    public interface ISalaService
    {
        SalaResponse GetSalaById(int idSala);
        IEnumerable<SalaResponse> GetSalas();

        void InsertSala(CreateSalaRequest sala);

        void UpdateSala(UpdateSalaRequest sala);

        void DeleteSala(int idSala);
    }
}
