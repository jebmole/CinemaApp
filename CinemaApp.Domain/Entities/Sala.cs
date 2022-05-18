using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaApp.Domain.Entities
{
    public partial class Sala
    {
        public Sala()
        {
            Funcion = new HashSet<Funcion>();
        }

        public int IdSala { get; set; }
        public string Nomenclatura { get; set; }
        public int Capacidad { get; set; }
        public bool EsDinamix { get; set; }
        public bool Activa { get; set; }

        public virtual ICollection<Funcion> Funcion { get; set; }
    }
}
