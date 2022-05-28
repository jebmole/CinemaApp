using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Application.Requests
{
    public class UpdateSalaRequest
    {
        public int IdSala { get; set; }
        public string Nomenclatura { get; set; }
        public int Capacidad { get; set; }
        public bool EsDinamix { get; set; }
        public bool Activa { get; set; }
    }
}
