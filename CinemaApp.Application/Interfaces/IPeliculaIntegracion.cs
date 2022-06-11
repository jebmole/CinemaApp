using CinemaApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Application.Interfaces
{
    public interface IPeliculaIntegracion
    {
        PeliculaTmbdResponse GetMovies();
    }
}
