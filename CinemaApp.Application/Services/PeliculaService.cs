using CinemaApp.Application.Interfaces;
using CinemaApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Application.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaIntegracion _integracion;
        public PeliculaService(IPeliculaIntegracion integracion)
        {
            _integracion = integracion;
        }

        public PeliculaTmbdResponse GetMovies()
        {
            return _integracion.GetMovies();
        }
    }
}
