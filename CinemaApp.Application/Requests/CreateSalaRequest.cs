using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaApp.Application.Requests
{
    public class CreateSalaRequest
    {
        [Required(ErrorMessage = "La nomenclatura es requerida")]
        [MaxLength(5, ErrorMessage ="La longitud maxima es 5 caracteres")]
        public string Nomenclatura { get; set; }

        [Required(ErrorMessage = "La Capacidad es requerida")]
        public int? Capacidad { get; set; }

        public bool EsDinamix { get; set; }

        public bool Activa { get; set; }
    }
}
