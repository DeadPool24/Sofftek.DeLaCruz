using AutoMapper;
using Sofftek.GestionComercial.Core.Entities;
using Sofftek.GestionComercial.Core.Helpers;
using Sofftek.GestionComercial.Core.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Infraestructure.Repository
{
    public class RepositoryVentas : IRepositoryVentas
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public RepositoryVentas(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void guardarVenta(Venta venta)
        {
            _context.Venta.Add(venta);
            _context.SaveChanges();
        }

        public List<Venta> listarVentas()
        {
            var result = (from item in _context.Venta
                          where item.estado == true
                          select item);
            return result.ToList();
        }

        public List<Venta> listarVentaPorAsesor(Guid id_asesor)
        {
            var result = (from item in _context.Venta
                          where item.estado == true && item.id_asesor.Equals(id_asesor)
                          select item);
            return result.ToList();
        }

        public void guardarDetalleVenta(DetalleVenta detalle)
        {
            _context.DetalleVenta.Add(detalle);
            _context.SaveChanges(); 
        }
    }
}
