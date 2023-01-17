using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Service.Entities
{
    public class Asesor
    {
        public Guid id_asesor { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string zona { get; set; }
        public bool estado { get; set; }
    }
}
