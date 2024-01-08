using RclProducts.Dto;

namespace RclProducts.Services.Interfaces
{
    public interface IProductsRestServices
    {
        Task<List<ProductDto>> GetAll();
    }
}
