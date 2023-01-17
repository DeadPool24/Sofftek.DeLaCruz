using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Service.Entities
{
    public class Articulo
    {
        public Guid id_producto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public decimal costo { get; set; }
        public int stock { get; set; }
        public bool estado { get; set; }
    }
}
