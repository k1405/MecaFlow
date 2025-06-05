using Abstracciones.Abstracciones;
using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;

namespace BackEnd.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ClienteService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Cliente Convertir(ClienteDTO cliente)
        {
            return new Cliente
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono
            };
        }

        ClienteDTO Convertir(Cliente cliente)
        {
            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono
            };
        }

        public void AddCliente(ClienteDTO cliente)
        {
            var clienteEntity = Convertir(cliente);
            _unidadDeTrabajo.ClienteDAL.Add(clienteEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteCliente(int id)
        {
            var cliente = new Cliente { Id = id };
            _unidadDeTrabajo.ClienteDAL.Remove(cliente);
            _unidadDeTrabajo.Complete();
        }

        public List<ClienteDTO> GetCliente()
        {
            var result = _unidadDeTrabajo.ClienteDAL.GetAllClientes();
            var clientes = new List<ClienteDTO>();

            foreach (var item in result)
            {
                clientes.Add(Convertir(item));
            }

            return clientes;
        }

        public void UpdateCliente(ClienteDTO cliente)
        {
            var clienteEntity = Convertir(cliente);
            _unidadDeTrabajo.ClienteDAL.Update(clienteEntity);
            _unidadDeTrabajo.Complete();
        }

        public ClienteDTO GetClienteById(int id)
        {
            var result = _unidadDeTrabajo.ClienteDAL.Get(id);
            return Convertir(result);
        }
    }
}
