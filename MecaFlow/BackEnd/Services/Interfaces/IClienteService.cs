using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IClienteService
    {
        void AddCliente(ClienteDTO cliente);
        void UpdateCliente(ClienteDTO cliente);
        void DeleteCliente(int id);
        List<ClienteDTO> GetCliente();
        ClienteDTO GetClienteById(int id);
    }
}
