namespace CinemaApp.Application.Requests
{
    public class CreateSalaRequest
    {
        public string Nomenclatura { get; set; }

        public int? Capacidad { get; set; }

        public bool EsDinamix { get; set; }

        public bool Activa { get; set; }
    }
}
