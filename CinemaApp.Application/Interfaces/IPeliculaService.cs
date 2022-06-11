using CinemaApp.Application.Responses;

namespace CinemaApp.Application.Interfaces
{
    public interface IPeliculaService
    {
        PeliculaTmbdResponse GetMovies();
    }
}