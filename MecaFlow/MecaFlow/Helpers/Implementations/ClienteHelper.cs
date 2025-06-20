using MecaFlow.ApiModels;
using MecaFlow.Helpers.Interfaces;
using MecaFlow.Models;
using Newtonsoft.Json;

namespace MecaFlow.Helpers.Implementations
{
    public class ClienteHelper : IClienteHelper
    {
        IServiceRepository _ServiceRepository;

        ClienteViewModel Convertir(ClienteApi cliente)
        {
           ClienteViewModel clienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono
                };
            return clienteViewModel;
        }


        public ClienteHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        public ClienteViewModel Add(ClienteViewModel cliente)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Cliente", cliente);
            if (response.IsSuccessStatusCode)
            {

                var content = response.Content.ReadAsStringAsync().Result;
            }
            return cliente;
        }

        public void Delete(int id)
        {
            HttpResponseMessage response = _ServiceRepository.DeleteResponse("api/Cliente/" + id.ToString());
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al eliminar el cliente");
            }
        }


        public List<ClienteViewModel> GetClientes()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Cliente");
            List<ClienteApi> clientes = new List<ClienteApi>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                clientes = JsonConvert.DeserializeObject<List<ClienteApi>>(content);
            }
            List<ClienteViewModel> lista = new List<ClienteViewModel>();
            foreach (var cliente in clientes)
            {
                lista.Add(Convertir(cliente));
            }
            return lista;
        }

        public ClienteViewModel GetCliente(int? id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Cliente/" + id.ToString());
            ClienteApi cliente = new ClienteApi();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<ClienteApi>(content);
            }

            ClienteViewModel resultado = Convertir(cliente);


            return resultado;
        }

        public ClienteViewModel Update(ClienteViewModel cliente)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/ Cliente", cliente);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<ClienteViewModel>(content);
            }
            else
            {
                throw new Exception("Error al actualizar el cliente");
            }
        }

    }
}
