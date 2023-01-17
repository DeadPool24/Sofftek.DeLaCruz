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
    public  class RepositoryArticulos : IRepositoryArticulos
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public RepositoryArticulos(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void guardarArticulo(Articulo articulo)
        {
            _context.Articulo.Add(articulo);
            _context.SaveChanges();
        }

        public List<Articulo> listarArticulos()
        {
            var articulos = (from data in _context.Articulo
                           where data.estado == true
                           select data).ToList();
            return articulos;
        }

        public Articulo obtenerArticuloPorId(Guid id_articulo)
        {
            var cliente = (from data in _context.Articulo
                           where data.estado == true && data.id_producto.Equals(id_articulo)
                           select data);
            return cliente.FirstOrDefault();
        }
    }
}
