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
    public  class RepositoryClientes : IRepositoryClientes
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public RepositoryClientes(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void guardarCliente(Cliente client)
        {
            _context.Cliente.Add(client);
            _context.SaveChanges();
        }

        public List<Cliente> listarCliente()
        {
            var cliente = (from data in _context.Cliente
                           where data.estado == true
                           select data).ToList();
            return cliente;
        }

        public Cliente obtenerClientePorId(Guid id_cliente)
        {
            var cliente = (from data in _context.Cliente
                           where data.estado == true && data.id_cliente.Equals(id_cliente)
                           select data);
            return cliente.FirstOrDefault();
        }
    }
}
