using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaApp.Domain.Entities
{
    public partial class Funcion
    {
        public Funcion()
        {
            Factura = new HashSet<Factura>();
        }

        public int IdFuncion { get; set; }
        public int IdPelicula { get; set; }
        public int IdSala { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int CapacidadMaxima { get; set; }
        public int AsientosDisponibles { get; set; }
        public decimal PrecioBoleta { get; set; }

        public virtual Pelicula IdPeliculaNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
