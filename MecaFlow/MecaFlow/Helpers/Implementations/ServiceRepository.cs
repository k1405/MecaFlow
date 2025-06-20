using MecaFlow.Helpers.Interfaces;

namespace MecaFlow.Helpers.Implementations
{
    public class ServiceRepository : IServiceRepository
    {


        public HttpClient Client { get; set; }

        public ServiceRepository(HttpClient _client, IConfiguration configuration)
        {
            Client = _client;
            string baseUrl = configuration.GetValue<string>("BackEnd:Url") ?? "";

            Client.BaseAddress = new Uri(baseUrl);


        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }

    }
}
