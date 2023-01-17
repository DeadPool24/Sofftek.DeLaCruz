using Sofftek.GestionComercial.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Core.Interface.IRepository
{
    public interface IRepositoryVentas
    {
        void guardarVenta(Venta venta);
        List<Venta> listarVentas();
        void guardarDetalleVenta(DetalleVenta detalle);
        List<Venta> listarVentaPorAsesor(Guid id_asesor);
    }
}
