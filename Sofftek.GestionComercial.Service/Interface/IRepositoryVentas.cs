using Sofftek.GestionComercial.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Service.Interface
{
    public interface IRepositoryVentas
    {
        void guardarVenta(Venta venta);
        List<Venta> listarVentas();
    }
}
