using AutoMapper;
using Sofftek.GestionComercial.Service.Entities;
using Sofftek.GestionComercial.Service.Helpers;
using Sofftek.GestionComercial.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Service.Repository
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
    }
}
