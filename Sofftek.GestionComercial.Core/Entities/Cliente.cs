using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Core.Entities
{
    public class Cliente
    {
        public Guid id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string numero_documento { get; set; }
        public bool estado { get; set; }
    }
}
