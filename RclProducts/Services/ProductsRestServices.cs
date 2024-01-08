using RclProducts.Dto;
using RclProducts.Services.Interfaces;
using System.Text.Json;

namespace RclProducts.Services
{
    public class ProductsRestServices : IProductsRestServices
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        private List<ProductDto> products;
        public ProductsRestServices() 
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<List<ProductDto>> GetAll()
        {
            products = new List<ProductDto>();

            Uri uri = new Uri("http://localhost:5238");

            try
            {
                HttpResponseMessage httpResponseMessage = await _client.GetAsync($"{uri}/sample-data/pizzas.json");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string content = await httpResponseMessage.Content.ReadAsStringAsync();
                    products = JsonSerializer.Deserialize<List<ProductDto>>(content, _serializerOptions)!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return products;
        }
    }
}
