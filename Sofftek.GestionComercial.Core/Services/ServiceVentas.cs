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

        public Guid guardarVenta(Venta venta)
        {
            venta.id_venta = Guid.NewGuid();
            _repository.guardarVenta(venta);
            return venta.id_venta;
        }

        public List<Venta> listarVentas()
        {
            return _repository.listarVentas();
        }

        public List<Venta> listarVentaPorAsesor(Guid id_asesor)
        {
            return _repository.listarVentaPorAsesor(id_asesor);
        }

        public void guardarDetalleVenta(List<DetalleVenta> detalle)
        {
            foreach (var item in detalle)
                _repository.guardarDetalleVenta(item);
        }
    }
}
