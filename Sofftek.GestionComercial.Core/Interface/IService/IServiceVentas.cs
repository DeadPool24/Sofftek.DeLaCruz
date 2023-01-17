using Sofftek.GestionComercial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Core.Interface.IService
{
    public interface IServiceVentas
    {
        Guid guardarVenta(Venta venta);
        List<Venta> listarVentas();
        List<Venta> listarVentaPorAsesor(Guid id_asesor);
        void guardarDetalleVenta(List<DetalleVenta> detalle);
    }
}
