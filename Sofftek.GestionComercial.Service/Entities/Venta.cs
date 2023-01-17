using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Service.Entities
{
    public class Venta
    {
        [Key]
        public Guid id_venta { get; set; }
        public Guid id_cliente { get; set; }
        public Guid id_asesor { get; set; }
        public decimal total_venta { get; set; }
        public DateTime fecha_venta { get; set; }
        public bool pagado { get; set; }
        public bool despachado { get; set; }
        public bool estado { get; set; }
    }
}
