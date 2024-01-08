using RclProducts.Dto;

namespace RclProducts.Services.Interfaces
{
    public interface ISizeRestServices
    {
        Task<List<SizeDto>> GetAll(string uidprod);
    }
}
