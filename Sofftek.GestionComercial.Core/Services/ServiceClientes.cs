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
    public class ServiceClientes : IServiceClientes
    {
        private readonly IRepositoryClientes _repository;
        private readonly IMapper _mapper;

        public ServiceClientes(
            IMapper mapper,
            IRepositoryClientes repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void guardarCliente(Cliente client)
        {
            client.id_cliente = Guid.NewGuid();
            _repository.guardarCliente(client);
        }

        public List<Cliente> listarCliente()
        {
            return _repository.listarCliente();
        }

        public Cliente obtenerClientePorId(Guid id_cliente)
        {
            return _repository.obtenerClientePorId(id_cliente);
        }
    }
}
