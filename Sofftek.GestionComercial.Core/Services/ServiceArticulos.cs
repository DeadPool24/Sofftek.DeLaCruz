using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sofftek.GestionComercial.Core.Entities;
using Sofftek.GestionComercial.Core.Interface.IRepository;
using Sofftek.GestionComercial.Core.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Core.Services
{
    public class ServiceArticulos : IServiceArticulos
    {
        private readonly IRepositoryArticulos _repository;
        private readonly IMapper _mapper;

        public ServiceArticulos(
            IMapper mapper,
            IRepositoryArticulos repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void guardarArticulo(Articulo articulo)
        {
            articulo.id_producto = new Guid();
            _repository.guardarArticulo(articulo);
        }

        public List<Articulo> listarArticulos()
        {
            return _repository.listarArticulos();
        }

        public Articulo obtenerArticuloPorId(Guid id_articulo)
        {
            return _repository.obtenerArticuloPorId(id_articulo);
        }
    }
}
