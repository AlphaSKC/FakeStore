using FakeStore.Domain.DTO;
using FakeStore.Domain.Entities;

namespace FakeStore.Services
{
    public class ProductServices : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>("https://fakestoreapi.com/products");
            return response;
        }

        public async Task<List<ProductDTO>> GetProductsByCurrency(string currency)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>($"https://fakestoreapi.com/products");
            var products = new List<ProductDTO>();
            switch (currency.ToUpper())
            {
                case "USD":
                    products = response.Select(p => new ProductDTO
                    {
                        id = p.id,
                        title = p.title,
                        price = p.price,
                        publicPrice = (float)(p.price + (p.price * .10)),
                        currency = "USD",
                        description = p.description,
                        category = p.category,
                        image = p.image
                    }).ToList();
                    break;
                case "MXN":
                    products = response.Select(p => new ProductDTO
                    {
                        id = p.id,
                        title = p.title,
                        price = p.price * 18,
                        publicPrice = (float)((p.price * (18)) + (p.price * .10)),
                        currency = "MXN",
                        description = p.description,
                        category = p.category,
                        image = p.image
                    }).ToList();
                    break;
                default:
                    throw new Exception("Currency not supported, only supported USD or MXN");
            }

            return products;
        }
    }
}
