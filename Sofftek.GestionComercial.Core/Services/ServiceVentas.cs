using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sofftek.GestionComercial.Core.Entities;
using Sofftek.GestionComercial.Core.Helpers;
using Sofftek.GestionComercial.Core.Interface.IRepository;
using Sofftek.GestionComercial.Core.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Core.Services
{
    public class ServiceVentas : IServiceVentas
    {
        private readonly IRepositoryVentas _repository;
        private readonly IMapper _mapper;

        public ServiceVentas(
            IMapper mapper,
            IRepositoryVentas repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void guardarVenta(Venta venta)
        {
            venta.id_venta = new Guid();
            _repository.guardarVenta(venta);
        }

        public List<Venta> listarVentas()
        {
           return _repository.listarVentas();
        }
    }
}
