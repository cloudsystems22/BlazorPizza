using RclProducts.Dto;
using RclProducts.Services.Interfaces;
using System.Text.Json;

namespace RclProducts.Services
{
    public class SizeRestServices : ISizeRestServices
    {

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        private List<SizeDto> _sizes;

        public SizeRestServices(HttpClient client)
        {
            _client = client;
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<List<SizeDto>> GetAll(string uidprod)
        {
            _sizes = new List<SizeDto>();

            Uri uri = new Uri(_client.BaseAddress!.ToString());

            try
            {
                HttpResponseMessage httpResponseMessage = await _client.GetAsync($"{uri}sample-data/size.json");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string content = await httpResponseMessage.Content.ReadAsStringAsync();
                    _sizes = JsonSerializer.Deserialize<List<SizeDto>>(content, _serializerOptions)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return _sizes.Where(s => s.UidItem == uidprod).ToList();
        }
    }
}
