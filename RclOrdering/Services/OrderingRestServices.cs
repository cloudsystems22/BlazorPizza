using RclOrdering.Dto;
using RclOrdering.Services.Interfaces;
using System.Text.Json;

namespace RclOrdering.Services
{
    public class OrderingRestServices : IOrderingRestServices
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        private List<OrderDto> _orders;
        public OrderingRestServices(HttpClient client)
        {
            _client = client;
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };


        }

        public async Task<List<OrderDto>> GetAll()
        {
            _orders = new List<OrderDto>();

            Uri uri = new Uri(_client.BaseAddress!.ToString());

            try
            {
                HttpResponseMessage httpResponseMessage = await _client.GetAsync($"{uri}sample-data/pedidos.json");
                if(httpResponseMessage.IsSuccessStatusCode)
                {
                    string content = await httpResponseMessage.Content.ReadAsStringAsync();
                    _orders = JsonSerializer.Deserialize<List<OrderDto>>(content, _serializerOptions)!;
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return _orders;
        }
    }
}
