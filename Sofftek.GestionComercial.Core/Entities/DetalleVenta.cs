using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Core.Entities
{
    public class DetalleVenta
    {
        public Guid id_venta { get; set; }
        public Guid id_producto { get; set; }
        public Guid cantidad { get; set; }
        public decimal precio_venta { get; set; }
        public decimal total_venta { get; set; }
        public bool estado { get; set; }
    }
}
