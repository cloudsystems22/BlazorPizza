using RclOrdering.Dto;

namespace RclOrdering.Services.Interfaces
{
    public interface IOrderingRestServices
    {
        Task<List<OrderDto>> GetAll();
    }
}
