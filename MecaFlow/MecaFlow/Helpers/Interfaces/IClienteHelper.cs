using MecaFlow.Models;

namespace MecaFlow.Helpers.Interfaces
{
        public interface IClienteHelper
        {
            List<ClienteViewModel> GetClientes();
            ClienteViewModel GetCliente(int? id);
            ClienteViewModel Add(ClienteViewModel cliente);
            ClienteViewModel Update(ClienteViewModel cliente);
            void Delete(int id);
        }
    }
