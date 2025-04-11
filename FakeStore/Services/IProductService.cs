using FakeStore.Domain.DTO;
using FakeStore.Domain.Entities;

namespace FakeStore.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<ProductDTO>> GetProductsByCurrency(string currency);
    }
}
