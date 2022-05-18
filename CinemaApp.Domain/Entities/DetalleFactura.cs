using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaApp.Domain.Entities
{
    public partial class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int IdFactura { get; set; }
        public Guid IdentificadorBoleta { get; set; }
        public bool Redimida { get; set; }
        public DateTime? FechaUso { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
    }
}
