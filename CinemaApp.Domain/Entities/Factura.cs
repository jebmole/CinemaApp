using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaApp.Domain.Entities
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }
        public int IdFuncion { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorServicio { get; set; }
        public decimal ValorIva { get; set; }
        public decimal ValorNeto { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Funcion IdFuncionNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
