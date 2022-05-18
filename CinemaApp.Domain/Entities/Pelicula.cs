using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaApp.Domain.Entities
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            Funcion = new HashSet<Funcion>();
        }

        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public int Duracion { get; set; }
        public string Director { get; set; }
        public string ActorPrincipal { get; set; }
        public bool Disponible { get; set; }

        public virtual ICollection<Funcion> Funcion { get; set; }
    }
}
